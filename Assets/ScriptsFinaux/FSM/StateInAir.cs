using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateInAir : BaseState
{
    public StateInAir(PlayerController playerController) : base(playerController) { }

    private float _yVelocity;
    private float _timeBeforeCatch;
    private bool _canCatch;
    
    public override void OnEnter()
    {
        PlayerController.PlayerAnimator.SetBool("InAir", true);
    }

    public override void OnUpdate()
    {
        _yVelocity = PlayerController.Rb.linearVelocity.y;
        if (PlayerController.HasJumped)
        {
            if (_timeBeforeCatch < 0.2)
            {
                _timeBeforeCatch += Time.deltaTime;
                _canCatch = false;
            }
            
            if (_timeBeforeCatch >= 0.2)
            {
                _canCatch = true;
            }
            
            if (_yVelocity <= 0)
            {
                PlayerController.Rb.AddForce(new Vector2(PlayerController.Move.x, 0));
            }
        }

        if (PlayerController.OutOfJetpack)
        {
            if (_yVelocity <= 0)
            {
                _canCatch = true;
                PlayerController.Rb.AddForce(new Vector2(PlayerController.Move.x * 8000 * Time.deltaTime, 0));
            }
        }
    }

    public override void OnExit()
    {
        _timeBeforeCatch = 0;
        PlayerController.OutOfJetpack = false;
        PlayerController.RightJumpEffect.SetActive(false);
        PlayerController.LeftJumpEffect.SetActive(false);
    }

    public override BaseState NextState()
    {
        //Shield state
        if (PlayerController.UseShield && PlayerController.CanShield)
        {
            return new StateShield(PlayerController);
        }
        
        //Wall state
        if (PlayerController.IsOnRightWall && _canCatch || PlayerController.IsOnLeftWall && _canCatch)
        {
            PlayerController.PlayerAnimator.SetBool("EndJump", true);
            return new StateWallCatch(PlayerController);
        }
        
        /*
        //Jetpack state
        if (PlayerControllerFinal.UseJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }*/
        
        //Idle state 
        if (PlayerController.IsGrounded && PlayerController.Move.x == 0 && _canCatch)
        {
            return new StateIdle(PlayerController);
        }
        
        //Walk state
        if (PlayerController.IsGrounded && PlayerController.Move.x != 0 && _canCatch)
        {
            return new StateWalk(PlayerController);
        }
        
        return null;
    }
}
