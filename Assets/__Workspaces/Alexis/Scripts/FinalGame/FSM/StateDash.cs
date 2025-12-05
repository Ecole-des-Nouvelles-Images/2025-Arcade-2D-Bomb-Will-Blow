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
    private List<GameObject> _ennemies = new List<GameObject>();
    
    public override void OnEnter()
    {
        Debug.Log("Enter");
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        _playerPosition = PlayerControllerFinal.PlayerPosition;
        _positionToReach = new Vector2(_playerPosition.position.x, _playerPosition.position.y + 15);
        
    }

    public override void OnUpdate()
    {
        Debug.Log("Onupdate");
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
            KillEnnemies();
            if (_ennemies.Count > 0)
            { 
                int i = _ennemies.Count - 1;
                GameObject ennemie = _ennemies[i];
                _ennemies.RemoveAt(i);
                //Destroy(ennemie);
            }
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

    private void KillEnnemies()
    {
        RaycastHit2D hit = Physics2D.Linecast(_playerPosition.position, _positionToReach,  LayerMask.GetMask("Ennemies"));
        if (hit.collider != null)
        {
            _ennemies.Add(hit.collider.gameObject);
        }
    }
}
