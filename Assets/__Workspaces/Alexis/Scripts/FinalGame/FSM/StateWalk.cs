using UnityEngine;

public class StateWalk : BaseState
{
    public StateWalk(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        Debug.Log("State walk Entry");
        PlayerControllerFinal.PlayerAnimator.SetBool("StartWalk",true);
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.PlayerAnimator.SetBool("Walking", true);
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.Rb.AddForce(new Vector2(PlayerControllerFinal.Move.x * Time.deltaTime * 10000, 0));
        if (PlayerControllerFinal.Move.x >= 0.2f)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2(Time.deltaTime * 5000, 0));
        }
        if (PlayerControllerFinal.Move.x <= -0.2f)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2(Time.deltaTime * -5000, 0));
        }
    }

    public override void OnExit()
    {
        PlayerControllerFinal.Walk = false;
        PlayerControllerFinal.PlayerAnimator.SetBool("Walking", false);
    }

    public override BaseState NextState()
    {
        //Wall state
        if (PlayerControllerFinal.IsOnRightWall || PlayerControllerFinal.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }

        //Idle state
        if (PlayerControllerFinal.Move == Vector2.zero)
        {
            return new StateIdle(PlayerControllerFinal);
        }
        
        //Jetpack state
        if (PlayerControllerFinal.UseJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        //InAir state
        if (!PlayerControllerFinal.IsGrounded && !PlayerControllerFinal.IsOnLeftWall &&
            !PlayerControllerFinal.IsOnRightWall)
        {
            return new StateInAir(PlayerControllerFinal);
        }
        
        return null;
    }
}
