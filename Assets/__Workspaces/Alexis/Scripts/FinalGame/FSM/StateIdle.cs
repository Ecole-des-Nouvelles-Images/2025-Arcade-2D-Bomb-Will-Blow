using UnityEngine;

public class StateIdle : BaseState
{
    public StateIdle(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.PlayerAnimator.SetBool("IdleGround", true);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("IdleGround", false);
    }

    public override BaseState NextState()
    {
        //Walk state
        if (PlayerControllerFinal.Walk && PlayerControllerFinal.CanWalk)
        {
            return new StateWalk(PlayerControllerFinal);
        }

        //JetpackState
        if (PlayerControllerFinal.UseJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }

        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        return null;
    }
}
