using UnityEngine;

public class StateDash : BaseState
{
    public StateDash(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    [SerializeField] private GameObject _DashKillZone;
    
    private float _timeToChargeDash = 0.5f;
    
    public override void OnEnter()
    {
        Debug.Log("Dash");
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        //Animator update
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
    }

    public override void OnExit()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        //Animator update
    }

    public override BaseState NextState()
    {
        //WallCatch state
        if (PlayerControllerFinal.IsOnRightWall || PlayerControllerFinal.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        return null;
    }

    private void LaunchDash()
    {
        _DashKillZone.SetActive(true);
        PlayerControllerFinal.Rb.AddForce(new Vector2(0,500));
        PlayerControllerFinal.DashRefillTime = 0;
        PlayerControllerFinal.CanDash = false;
    }
}
