using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateJump : BaseState
{
    public StateJump(PlayerController playerController) : base(playerController) { }
    
    
    public override void OnEnter()
    {
        PlayerController.PlayerAnimator.SetTrigger("StartJump");
        PlayerController.Rb.linearVelocity = Vector2.zero;
        if (PlayerController.IsOnRightWall)
        {
            DoJumpToLeftWall();
        }

        if (PlayerController.IsOnLeftWall)
        {
            DoJumpToRightWall();
        }

    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        PlayerController.HasJumped = true;
    }

    public override BaseState NextState()
    {
        //InAir state
        if (!PlayerController.IsOnLeftWall || !PlayerController.IsOnRightWall && !PlayerController.IsInJetpack)
        {
            return new StateInAir(PlayerController);
        }

        return null;
    }

    private void DoJumpToLeftWall()
    {
        //PlayerControllerFinal.Rb.AddForce(new Vector2(- 1000, 1000));
        if (PlayerController.IsGrounded)
        {
            PlayerController.Rb.AddForce(new Vector2(- 1000 * Mathf.Abs(PlayerController.Move.x) * Mathf.Abs(PlayerController.JumpXDynamic), 1000));
        }
        else
        {
            PlayerController.Rb.AddForce(new Vector2(- 1000 * Mathf.Abs(PlayerController.Move.x) * Mathf.Abs(PlayerController.JumpXDynamic), 1000 * PlayerController.JumpY));
            PlayerController.CanJumpToLeftWall = false;
        }
        PlayerController.LeftJumpEffect.SetActive(true);
    }

    private void DoJumpToRightWall()
    {
        
        //PlayerControllerFinal.Rb.AddForce(new Vector2(1000, 1000));
        if (PlayerController.IsGrounded)
        {
            PlayerController.Rb.AddForce(new Vector2(1000 * Mathf.Abs(PlayerController.Move.x) * Mathf.Abs(PlayerController.JumpXDynamic), 1000));
        }
        else
        {
            PlayerController.Rb.AddForce(new Vector2(1000 * Mathf.Abs(PlayerController.Move.x) * Mathf.Abs(PlayerController.JumpXDynamic), 1000 * PlayerController.JumpY));
            PlayerController.CanJumpToRightWall = false;
        }
        PlayerController.RightJumpEffect.SetActive(true);
    }
}
