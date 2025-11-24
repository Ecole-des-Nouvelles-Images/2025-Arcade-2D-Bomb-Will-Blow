using UnityEngine;

public class StateInAir : BaseState
{
    public StateInAir(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float _yVelocity;
    
    public override void OnEnter()
    {
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
        //state à faire : jetpack - wall - shield
        
        return NextState();
    }
}
