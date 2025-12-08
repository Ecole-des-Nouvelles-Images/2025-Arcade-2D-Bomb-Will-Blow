using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateDash : BaseState
{
    public StateDash(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    private float _timeToChargeDash = 0.5f;
    private Transform _playerPosition;
    private Vector2 _positionToReach;
    private bool _hasDashed;
    
    public override void OnEnter()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        _playerPosition = PlayerControllerFinal.PlayerPosition;
        _positionToReach = new Vector2(_playerPosition.position.x, _playerPosition.position.y + 30);
        
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

        
        if (_playerPosition.position.y >= _positionToReach.y)
        {
            PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
            PlayerControllerFinal.PlayerPosition.position = _positionToReach;
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
        if (PlayerControllerFinal.IsOnRightWall && _hasDashed|| PlayerControllerFinal.IsOnLeftWall && _hasDashed)
        {
            _hasDashed = false;
            PlayerControllerFinal.Hurtbox.SetActive(true);
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        return null;
    }

    private void LaunchDash()
    {
        KillEnnemies();
        PlayerControllerFinal.Hurtbox.SetActive(false);
        PlayerControllerFinal.Rb.AddForce(new Vector2(0,700));
        PlayerControllerFinal.DashRefillTime = 0;
        PlayerControllerFinal.CanDash = false;
    }

    private void KillEnnemies()
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(_playerPosition.position, _positionToReach,  LayerMask.GetMask("Ennemies"));
        
        foreach (var hit in hits) 
        {
            hit.collider.gameObject.GetComponent<IKillable>().Kill();
        }
    }
}