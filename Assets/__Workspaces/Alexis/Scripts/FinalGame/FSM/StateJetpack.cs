using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float JetpackForce = 1000;
    
    public override void OnEnter()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("Jetpack", true);
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.IsInJetpack = true;
        DoJetpack();
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.JetpackFuel -= Time.deltaTime;
        if (PlayerControllerFinal.JetpackFuel > 0)
        {
            JetpackHorizontalMobility();
        }
        /*JetpackHorizontalMobility();
        PlayerControllerFinal.JetpackFuel -= Time.deltaTime;
        if (PlayerControllerFinal.JetpackFuel <= 0)
        {
            PlayerControllerFinal.IsInJetpack = false;
        }*/
    }

    public override void OnExit()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("Jetpack", false);
        PlayerControllerFinal.IsInJetpack = false;
    }

    public override BaseState NextState()
    {
        //InAir state
        if (PlayerControllerFinal.JetpackFuel <= 0)
        {
            return new StateInAir(PlayerControllerFinal);
        }
        
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        //Wall sate
        if (PlayerControllerFinal.IsOnLeftWall || PlayerControllerFinal.IsOnRightWall)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        return null;
    }

    private void DoJetpack()
    {
        PlayerControllerFinal.IsInJetpack = true;
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime * 4000, JetpackForce * Time.deltaTime)); 
    }

    private void JetpackHorizontalMobility()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime * 4000, JetpackForce * Time.deltaTime));
    }
}
