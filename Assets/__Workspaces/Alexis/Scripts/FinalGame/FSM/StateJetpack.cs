using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float JetpackForce = 5;
    
    public override void OnEnter()
    {
        Debug.Log("Jetpack");
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        //Animator update
        DoJetpack();
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.JetpackFuel -= Time.deltaTime;
        if (PlayerControllerFinal.JetpackFuel <= 0)
        {
            PlayerControllerFinal.IsInJetpack = false;
        }
    }

    public override void OnExit()
    {
        
    }

    public override BaseState NextState()
    {
        //InAir state
        if (!PlayerControllerFinal.IsOnLeftWall || !PlayerControllerFinal.IsOnRightWall && !PlayerControllerFinal.IsInJetpack)
        {
            return new StateInAir(PlayerControllerFinal);
        }
        
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        return null;
    }

    private void DoJetpack()
    {
        PlayerControllerFinal.IsInJetpack = true;
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime, JetpackForce), ForceMode2D.Force); 
    }
}
