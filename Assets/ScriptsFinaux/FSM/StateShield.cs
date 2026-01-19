using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateShield : BaseState
{
    public StateShield(PlayerController playerController) : base(playerController) { }
    
    public override void OnEnter()
    {
        PlayerController.PlayerAudio.PlayOneShot(PlayerController.ShieldSound);
        PlayerController.UseShield = true;
        Object.Instantiate(PlayerController.ShieldEffect, PlayerController.transform.position, Quaternion.identity, PlayerController.transform);
        PlayerController.Hurtbox.SetActive(false);
        PlayerController.ShieldTimer = 0;
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        PlayerController.UseShield = false;
        PlayerController.Hurtbox.SetActive(false);
    }

    public override BaseState NextState()
    {
        //Death state
        if (!PlayerController.Alive) {
            return new StateDeath(PlayerController);
        }
        
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

        return new StateIdle(PlayerController);
        }
}
