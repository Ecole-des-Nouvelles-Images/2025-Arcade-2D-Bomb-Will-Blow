using UnityEngine;

public class StateInAir : BaseState
{
    public StateInAir(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float _yVelocity;
    private float _timeBeforeCatch;
    private bool _canCatch;
    
    public override void OnEnter()
    {
        Debug.Log("InAir");
        
        /*{
            PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        }*/
    }

    public override void OnUpdate()
    {
        if (_timeBeforeCatch < 0.2)
        {
            _timeBeforeCatch += Time.deltaTime;
            _canCatch = false;
        }

        if (_timeBeforeCatch >= 0.2)
        {
            _canCatch = true;
        }
        
        _yVelocity = PlayerControllerFinal.Rb.linearVelocity.y;
        if (_yVelocity <= 0)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2(PlayerControllerFinal.Move.x, 0));
        }
    }

    public override void OnExit()
    {
        _timeBeforeCatch = 0;
    }

    public override BaseState NextState()
    {
        //Shield state
        if (PlayerControllerFinal.UseShield)
        {
            return new StateShield(PlayerControllerFinal);
        }
        
        //Wall state
        if (PlayerControllerFinal.IsOnRightWall && _canCatch || PlayerControllerFinal.IsOnLeftWall && _canCatch)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        //Jetpack state
        if (PlayerControllerFinal.UseJetpack)
        {
            return new StateJetpack(PlayerControllerFinal);
        }
        
        return null;
    }
}
