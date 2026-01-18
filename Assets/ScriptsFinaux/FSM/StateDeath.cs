using ScriptsFinaux.Player;
using UnityEngine;

public class StateDeath : BaseState
{
    public StateDeath(PlayerController playerController) : base(playerController) { }

    public override void OnEnter() {
        PlayerController.PlayerAnimator.SetBool("IsDead", true);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
    }

    public override BaseState NextState()
    {
        if (PlayerController.IsGrounded)
        {
            return new StateIdle(PlayerController);
        }

        return null;
    }
}
