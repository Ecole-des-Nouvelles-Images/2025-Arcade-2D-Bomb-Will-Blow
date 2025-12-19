using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateIdle : BaseState
{
    public StateIdle(PlayerController playerController) : base(playerController) { }
    
    public override void OnEnter()
    {
        PlayerController.PlayerAnimator.SetBool("StartWalk",false);
        PlayerController.PlayerAnimator.SetBool("InAir", false);
        PlayerController.PlayerAnimator.SetBool("EndRun", true);
        PlayerController.Rb.linearVelocity = Vector2.zero;
        PlayerController.PlayerAnimator.SetBool("IdleGround", true);
    }

    public override void OnUpdate()
    {
        PlayerController.Rb.linearVelocity = Vector2.zero;
    }

    public override void OnExit()
    {
        PlayerController.PlayerAnimator.SetBool("IdleGround", false);
        PlayerController.PlayerAnimator.SetBool("EndRun", false);
    }

    public override BaseState NextState()
    {
        //Walk state
        if (PlayerController.Walk && PlayerController.CanWalk && PlayerController.Move.x >= 0.2f || PlayerController.Move.x <= -0.2f)
        {
            return new StateWalk(PlayerController);
        }

        //JetpackState
        if (PlayerController.UseJetpack)
        {
            return new StateJetpack(PlayerController);
        }

        //Shield state
        if (PlayerController.UseShield && PlayerController.CanShield)
        {
            return new StateShield(PlayerController);
        }
        
        return null;
    }
}
