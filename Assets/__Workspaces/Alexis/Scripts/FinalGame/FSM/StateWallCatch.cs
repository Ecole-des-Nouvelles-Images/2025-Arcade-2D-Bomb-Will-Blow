using UnityEngine;

public class StateWallCatch : BaseState
{
    public StateWallCatch(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private bool _canGetSpeed;
    private bool _activatesOnlyOnce;
    private float _timerBeforeFall;
    private float _timeToReach = 0.5f;

    public override void OnEnter()
    {
        Debug.Log("WallCatch");
        PlayerControllerFinal.Rb.gravityScale = 0;
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.PlayerAnimator.SetBool("IdleWall", true);
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.CanWalk = false;
        
        if (!_activatesOnlyOnce)
        {
            _timerBeforeFall += Time.deltaTime;
        }
        
        if (_timerBeforeFall >= _timeToReach)
        {
            _canGetSpeed = true;
        }

        if (_canGetSpeed)
        {
            DoWallSlide();
        }
    }

    public override void OnExit()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("IdleWall", false);
    }

    public override BaseState NextState()
    {
        //InAir state
        if (PlayerControllerFinal.Jump)
        {
            return new StateJump(PlayerControllerFinal);
        }
        
        //Jetpack state
        if (PlayerControllerFinal.UseJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        return null;
    }

    private void DoWallSlide()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2(0, - 1));
        _canGetSpeed = false;
        _activatesOnlyOnce = false;
    }
}
