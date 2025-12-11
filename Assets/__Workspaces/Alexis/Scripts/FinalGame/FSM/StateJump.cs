using UnityEngine;

public class StateJump : BaseState
{
    public StateJump(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        Debug.Log("Jump");
        PlayerControllerFinal.PlayerAnimator.SetTrigger("StartJump");
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        if (PlayerControllerFinal.IsOnRightWall)
        {
            DoJumpToLeftWall();
        }

        if (PlayerControllerFinal.IsOnLeftWall)
        {
            DoJumpToRightWall();
        }

    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        ;
    }

    public override BaseState NextState()
    {
        //InAir state
        if (!PlayerControllerFinal.IsOnLeftWall || !PlayerControllerFinal.IsOnRightWall && !PlayerControllerFinal.IsInJetpack)
        {
            return new StateInAir(PlayerControllerFinal);
        }

        return null;
    }

    private void DoJumpToLeftWall()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2(- 1000, 1000));
        PlayerControllerFinal.CanJumpToLeftWall = false;
    }

    private void DoJumpToRightWall()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2(1000, 1000));
        PlayerControllerFinal.CanJumpToRightWall = false;
    }
}
