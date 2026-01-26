using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateWalk : BaseState
{
    public StateWalk(PlayerController playerController) : base(playerController) { }
    
    public override void OnEnter()
    {
        PlayerController.PlayerAnimator.SetBool("StartWalk",true);
        PlayerController.Rb.linearVelocity = Vector2.zero;
        PlayerController.PlayerAnimator.SetBool("Walking", true);
    }

    public override void OnUpdate()
    {
        PlayerController.PlayerAudio.PlayOneShot(PlayerController.RunSounds[Random.Range(0, PlayerController.RunSounds.Count)]);
        float moveX = PlayerController.Move.x * Time.deltaTime * PlayerController.PlayerData.MoveSpeed;
        PlayerController.Rb.linearVelocity = new Vector2(moveX, PlayerController.Rb.linearVelocity.y);
    }

    public override void OnExit()
    {
        PlayerController.PlayerAudio.Stop();
        PlayerController.Walk = false;
        PlayerController.PlayerAnimator.SetBool("Walking", false);
    }

    public override BaseState NextState()
    {
        //Death state
        if (!PlayerController.Alive) {
            return new StateDeath(PlayerController);
        }
        
        //Wall state
        if (PlayerController.IsOnRightWall || PlayerController.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerController);
        }

        //Idle state
        if (PlayerController.Move == Vector2.zero)
        {
            return new StateIdle(PlayerController);
        }
        
        //Shield state
        if (PlayerController.UseShield)
        {
            return new StateShield(PlayerController);
        }
        
        //InAir state
        if (!PlayerController.IsGrounded && !PlayerController.IsOnLeftWall &&
            !PlayerController.IsOnRightWall)
        {
            return new StateInAir(PlayerController);
        }
        
        return null;
    }
}
