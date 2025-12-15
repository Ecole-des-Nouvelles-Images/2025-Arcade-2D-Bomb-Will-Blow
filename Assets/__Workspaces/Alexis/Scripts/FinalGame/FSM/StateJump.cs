using UnityEngine;

public class StateJump : BaseState
{
    public StateJump(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
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
        /*if (PlayerControllerFinal.Move.y < 0)
        {
            _adjustJumpValueY = 0;
        }
        else if (PlayerControllerFinal.Move.y > 0.7f)
        {
            _adjustJumpValueY = 0.7f;
        }
        else
        {
            _adjustJumpValueY = PlayerControllerFinal.Move.y;
        }
        Debug.Log("Valeur ajustée de saut en y = " + _adjustJumpValueY);*/
    }

    public override void OnExit()
    {
        
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
        //PlayerControllerFinal.Rb.AddForce(new Vector2(- 1000, 1000));
        if (PlayerControllerFinal.IsGrounded)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2(- 1000 * Mathf.Abs(PlayerControllerFinal.Move.x) * Mathf.Abs(PlayerControllerFinal.JumpXDynamic), 1000));
        }
        
        PlayerControllerFinal.Rb.AddForce(new Vector2(- 1000 * Mathf.Abs(PlayerControllerFinal.Move.x) * Mathf.Abs(PlayerControllerFinal.JumpXDynamic), 1000 * PlayerControllerFinal.JumpY));
        PlayerControllerFinal.CanJumpToLeftWall = false;
    }

    private void DoJumpToRightWall()
    {
        
        //PlayerControllerFinal.Rb.AddForce(new Vector2(1000, 1000));
        if (PlayerControllerFinal.IsGrounded)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2(1000 * Mathf.Abs(PlayerControllerFinal.Move.x) * Mathf.Abs(PlayerControllerFinal.JumpXDynamic), 1000));
        }
        
        PlayerControllerFinal.Rb.AddForce(new Vector2(1000 * Mathf.Abs(PlayerControllerFinal.Move.x) * Mathf.Abs(PlayerControllerFinal.JumpXDynamic), 1000 * PlayerControllerFinal.JumpY));
        PlayerControllerFinal.CanJumpToRightWall = false;
    }
}
