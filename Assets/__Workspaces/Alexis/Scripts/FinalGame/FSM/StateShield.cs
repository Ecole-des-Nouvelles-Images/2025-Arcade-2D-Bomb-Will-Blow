using __Workspaces.Alexis.Scripts.FinalGame;
using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;

public class StateShield : BaseState
{
    public StateShield(PlayerController playerController) : base(playerController) { }
    
    public override void OnEnter()
    {
        PlayerController.UseShield = true;
        DoShield();
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        PlayerController.UseShield = false;
    }

    public override BaseState NextState()
    {
        //Walk state
        if (PlayerController.Walk && PlayerController.CanWalk)
        {
            return new StateWalk(PlayerController);
        }
        
        //WallCatch state
        if (PlayerController.IsOnRightWall || PlayerController.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerController);
        }
        
        //InAir state
        if (!PlayerController.IsOnLeftWall || !PlayerController.IsOnRightWall && !PlayerController.IsInJetpack)
        {
            return new StateInAir(PlayerController);
        }
        
        if (PlayerController.Move == Vector2.zero)
        {
            return new StateIdle(PlayerController);
        }
        
        return null;
    }

    private void DoShield()
    {
        PlayerController.ShieldTimer = 0;
        PlayerController.ShieldEffect.SetActive(true);
        PlayerController.Hurtbox.SetActive(false);
        PlayerController.CanUseShield = false;
    }
}
