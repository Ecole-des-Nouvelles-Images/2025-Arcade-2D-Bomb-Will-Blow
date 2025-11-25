using UnityEngine;

public class StateShield : BaseState
{
    public StateShield(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        Debug.Log("Shield");
        PlayerControllerFinal.UseShield = true;
        DoShield();
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        PlayerControllerFinal.UseShield = false;
    }

    public override BaseState NextState()
    {
        //Walk state
        if (PlayerControllerFinal.Walk && PlayerControllerFinal.CanWalk)
        {
            return new StateWalk(PlayerControllerFinal);
        }
        
        //WallCatch state
        if (PlayerControllerFinal.IsOnRightWall || PlayerControllerFinal.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        //InAir state
        if (!PlayerControllerFinal.IsOnLeftWall || !PlayerControllerFinal.IsOnRightWall && !PlayerControllerFinal.IsInJetpack)
        {
            return new StateInAir(PlayerControllerFinal);
        }
        
        //JetpackState
        if (PlayerControllerFinal.IsInJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        if (PlayerControllerFinal.Move == Vector2.zero)
        {
            return new StateIdle(PlayerControllerFinal);
        }
        
        return null;
    }

    private void DoShield()
    {
        PlayerControllerFinal.ShieldEffect.SetActive(true);
    }
}
