using ScriptsFinaux.Player;
using UnityEngine;

public class StateDeath : BaseState
{
    public StateDeath(PlayerController playerController) : base(playerController) { }

    public override void OnEnter()
    {
        Debug.Log("State Death");
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override BaseState NextState()
    {
        if (PlayerController.IsGrounded && PlayerController.Move.x == 0)
        {
            return new StateIdle(PlayerController);
        }

        return null;
    }
}
