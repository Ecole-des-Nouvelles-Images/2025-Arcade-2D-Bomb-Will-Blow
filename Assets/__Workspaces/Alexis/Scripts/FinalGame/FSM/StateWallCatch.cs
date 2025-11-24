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
        return NextState();
    }

    private void DoWallSlide()
    {
        PlayerControllerFinal.Rb.AddForce(new Vector2(0,10));
        _canGetSpeed = false;
        _activatesOnlyOnce = false;
    }
}
