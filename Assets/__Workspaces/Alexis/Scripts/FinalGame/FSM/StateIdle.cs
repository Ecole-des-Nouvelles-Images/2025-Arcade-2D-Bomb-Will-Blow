using UnityEngine;

public class StateIdle : BaseState
{
    public StateIdle(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        //Animator update
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        //Animator update
    }

    public override BaseState NextState()
    {
        //Walk state
        if (PlayerControllerFinal.Walk && PlayerControllerFinal.CanWalk)
        {
            return new StateWalk(PlayerControllerFinal);
        }

        //JetpackState
        if (PlayerControllerFinal.IsInJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        return null;
    }
}
