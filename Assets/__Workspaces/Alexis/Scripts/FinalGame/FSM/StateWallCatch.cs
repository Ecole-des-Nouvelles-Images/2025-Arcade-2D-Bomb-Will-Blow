using UnityEngine;

public class StateWallCatch : BaseState
{
    public StateWallCatch(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private bool _canGetSpeed;
    private bool _activatesOnlyOnce;
    private float _timerBeforeFall;
    private float _timeToReach;

    public override void OnEnter()
    {
        Debug.Log("WallCatch");
        PlayerControllerFinal.Rb.gravityScale = 0;
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
        
    }

    public override BaseState NextState()
    {
        //InAir state
        if (PlayerControllerFinal.Jump)
        {
            return new StateJump(PlayerControllerFinal);
        }
        
        //Jetpack state
        if (PlayerControllerFinal.IsInJetpack)
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
