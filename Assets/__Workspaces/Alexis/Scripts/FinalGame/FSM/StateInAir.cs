using UnityEngine;

public class StateInAir : BaseState
{
    public StateInAir(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float _yVelocity;
    private float _timeBeforeCatch;
    private bool _canCatch;
    
    public override void OnEnter()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("InAir", true);
    }

    public override void OnUpdate()
    {
        _yVelocity = PlayerControllerFinal.Rb.linearVelocity.y;
        if (PlayerControllerFinal.HasJumped)
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
                PlayerControllerFinal.Rb.AddForce(new Vector2(PlayerControllerFinal.Move.x, 0));
            }
        }

        if (PlayerControllerFinal.OutOfJetpack)
        {
            if (_yVelocity <= 0)
            {
                _canCatch = true;
                PlayerControllerFinal.Rb.AddForce(new Vector2(PlayerControllerFinal.Move.x * 8000 * Time.deltaTime, 0));
            }
        }
    }

    public override void OnExit()
    {
        _timeBeforeCatch = 0;
        PlayerControllerFinal.OutOfJetpack = false;
        PlayerControllerFinal.PlayerAnimator.SetBool("EndJump", true);
        PlayerControllerFinal.RightJumpEffect.SetActive(false);
        PlayerControllerFinal.LeftJumpEffect.SetActive(false);
    }

    public override BaseState NextState()
    {
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        //Wall state
        if (PlayerControllerFinal.IsOnRightWall && _canCatch || PlayerControllerFinal.IsOnLeftWall && _canCatch)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        /*
        //Jetpack state
        if (PlayerControllerFinal.UseJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }*/
        
        //Idle state 
        if (PlayerControllerFinal.IsGrounded && PlayerControllerFinal.Move.x == 0 && _canCatch)
        {
            return new StateIdle(PlayerControllerFinal);
        }
        
        //Walk state
        if (PlayerControllerFinal.IsGrounded && PlayerControllerFinal.Move.x != 0 && _canCatch)
        {
            return new StateWalk(PlayerControllerFinal);
        }
        
        return null;
    }
}
