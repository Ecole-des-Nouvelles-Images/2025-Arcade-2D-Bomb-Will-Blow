using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float JetpackForce = 250;
    
    public override void OnEnter()
    {
        Debug.Log("Jetpack");
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.IsInJetpack = true;
        //Animator update
        DoJetpack();
    }

    public override void OnUpdate()
    {
        JetpackHorizontalMobility();
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
        //!PlayerControllerFinal.IsOnLeftWall || !PlayerControllerFinal.IsOnRightWall && !PlayerControllerFinal.IsInJetpack
        if (PlayerControllerFinal.JetpackFuel <= 0)
        {
            /*PlayerControllerFinal.Rb.AddForce(new Vector2 (0, - JetpackForce));*/
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
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime * 4000, JetpackForce)); 
    }

    private void JetpackHorizontalMobility()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime * 4000, 10));
    }
}
