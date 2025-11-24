using UnityEngine;

public class StateWalk : BaseState
{
    public StateWalk(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        //Animator update
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2(PlayerControllerFinal.Move.x * Time.deltaTime, 0));
    }

    public override void OnExit()
    {
        //Animator Update
    }

    public override BaseState NextState()
    {
        //Wall state
        if (PlayerControllerFinal.IsOnRightWall || PlayerControllerFinal.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }

        //Idle state
        if (PlayerControllerFinal.Move == Vector2.zero)
        {
            return new StateIdle(PlayerControllerFinal);
        }
        
        //Jetpack state
        if (PlayerControllerFinal.IsInJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        return null;
    }
}
