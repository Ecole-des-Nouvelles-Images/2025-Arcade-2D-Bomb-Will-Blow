using UnityEngine;

public class StateInAir : BaseState
{
    public StateInAir(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float _yVelocity;
    
    public override void OnEnter()
    {
        Debug.Log("InAir");
        PlayerControllerFinal.Rb.gravityScale = 0;
    }

    public override void OnUpdate()
    {
        _yVelocity = PlayerControllerFinal.Rb.linearVelocity.y;
        if (_yVelocity <= 0)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2(PlayerControllerFinal.Move.x, 0));
        }
    }

    public override void OnExit()
    {
        
    }

    public override BaseState NextState()
    {
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        //Wall state
        if (PlayerControllerFinal.IsOnRightWall || PlayerControllerFinal.IsOnLeftWall)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        //Jetpack state
        if (PlayerControllerFinal.IsInJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        return null;
    }
}
