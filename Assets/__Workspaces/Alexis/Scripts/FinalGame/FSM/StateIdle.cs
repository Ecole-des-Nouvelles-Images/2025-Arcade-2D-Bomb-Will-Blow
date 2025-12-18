using UnityEngine;

public class StateIdle : BaseState
{
    public StateIdle(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        Debug.Log("State Idle Entry");
        PlayerControllerFinal.PlayerAnimator.SetBool("StartWalk",false);
        PlayerControllerFinal.PlayerAnimator.SetBool("InAir", false);
        PlayerControllerFinal.PlayerAnimator.SetBool("EndRun", true);
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.PlayerAnimator.SetBool("IdleGround", true);
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
    }

    public override void OnExit()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("IdleGround", false);
        PlayerControllerFinal.PlayerAnimator.SetBool("EndRun", false);
    }

    public override BaseState NextState()
    {
        //Walk state
        if (PlayerControllerFinal.Walk && PlayerControllerFinal.CanWalk && PlayerControllerFinal.Move.x >= 0.2f || PlayerControllerFinal.Move.x <= -0.2f)
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
