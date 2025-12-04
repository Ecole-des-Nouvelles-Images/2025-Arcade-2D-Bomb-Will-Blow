using UnityEngine;

public class StateDash : BaseState
{
    public StateDash(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    private float _timeToChargeDash = 0.5f;
    private Transform _playerPosition;
    private Transform _positionToReach;
    private bool _hasDashed;
    
    public override void OnEnter()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        _playerPosition.position = PlayerControllerFinal.PlayerPosition.position;
        _positionToReach.position = new Vector2(_playerPosition.position.x, _playerPosition.position.y + 15);
    }

    public override void OnUpdate()
    {
        
        if (_timeToChargeDash <= 1.5f )
        {
            _timeToChargeDash += Time.deltaTime;
        }

        if (_timeToChargeDash >= 1.5f)
        {
            LaunchDash();
        }

        if (_playerPosition.position.y >= _positionToReach.position.y)
        {
            PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
            PlayerControllerFinal.PlayerPosition.position = _positionToReach.position;
            _hasDashed = true;
        }
    }

    public override void OnExit()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
    }

    public override BaseState NextState()
    {
        //WallCatch state
        if (PlayerControllerFinal.IsOnRightWall || PlayerControllerFinal.IsOnLeftWall && _hasDashed)
        {
            _hasDashed = false;
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        return null;
    }

    private void LaunchDash()
    {
        Debug.Log("Dash");
        PlayerControllerFinal.Rb.AddForce(new Vector2(0,1000));
        PlayerControllerFinal.DashRefillTime = 0;
        PlayerControllerFinal.CanDash = false;
    }
}
