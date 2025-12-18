using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;

public class StateDash : BaseState
{
    public StateDash(PlayerController playerController) : base(playerController) { }
    
    private float _dashTimer;
    private Transform _playerPosition;
    private Vector2 _positionToReach;

    private bool IsOnWall => PlayerController.IsOnRightWall || PlayerController.IsOnLeftWall;
    
    public override void OnEnter()
    {
        PlayerController.Rb.linearVelocity = Vector2.zero;
        _playerPosition = PlayerController.transform;
        _positionToReach = (Vector2) _playerPosition.position + PlayerController.PlayerData.DashDeathLine;
        PlayerController.DashTimer = 0;
        
        PlayerController.PlayerVisual.SetActive(false);
        PlayerController.Hurtbox.SetActive(false);
        
        if (PlayerController.IsOnLeftWall)
        {
            Object.Instantiate(PlayerController.DashLeftSide, PlayerController.transform.position, Quaternion.identity);
        }

        if (PlayerController.IsOnRightWall)
        {
            Object.Instantiate(PlayerController.DashRightSide, PlayerController.transform.position, Quaternion.identity);
        }
        
        RaycastHit2D[] hits = Physics2D.LinecastAll(_playerPosition.position, _positionToReach,  LayerMask.GetMask("Ennemies"));
        
        foreach (var hit in hits) 
        {
            hit.collider.gameObject.GetComponent<IKillable>().Kill();
        }
    }

    public override void OnUpdate()
    {
        _dashTimer += Time.deltaTime;
        float linearVelocityX = PlayerController.Rb.linearVelocityX;
        float dashVelocity = PlayerController.PlayerData.DashCurve.Evaluate(_dashTimer / PlayerController.PlayerData.DashDuration) 
                             * PlayerController.PlayerData.DashForce;
        
        PlayerController.Rb.linearVelocity = new Vector2(linearVelocityX,  dashVelocity);
    }

    public override void OnExit()
    {
        PlayerController.PlayerVisual.SetActive(true);
        PlayerController.Hurtbox.SetActive(true);
        PlayerController.Rb.linearVelocity = Vector2.zero;
    }

    public override BaseState NextState()
    {
        if (_dashTimer <= PlayerController.PlayerData.DashDuration) return null;
        if (IsOnWall) return new StateWallCatch(PlayerController);

        return new StateInAir(PlayerController);
    }
}