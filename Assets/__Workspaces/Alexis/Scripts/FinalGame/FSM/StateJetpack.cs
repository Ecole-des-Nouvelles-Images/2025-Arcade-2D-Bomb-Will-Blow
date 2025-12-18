using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float JetpackForce = 25000;
    
    private float _timeBeforeCatch;
    private bool _canCatch;
    
    public override void OnEnter()
    {
        Debug.Log("State Jetpack Entry");
        PlayerControllerFinal.PlayerAnimator.SetBool("Jetpack", true);
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.IsInJetpack = true;
        DoJetpack();
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.JetpackFuel -= Time.deltaTime;
        if (PlayerControllerFinal.JetpackFuel > 0)
        {
            JetpackHorizontalMobility();
        }
        
        if (_timeBeforeCatch < 0.2)
        {
            _timeBeforeCatch += Time.deltaTime;
            _canCatch = false;
        }
            
        if (_timeBeforeCatch >= 0.2)
        {
            _canCatch = true;
        }
    }

    public override void OnExit()
    {
        PlayerControllerFinal.PlayerAnimator.SetBool("Jetpack", false);
        PlayerControllerFinal.IsInJetpack = false;
    }

    public override BaseState NextState()
    {
        //InAir state
        if (PlayerControllerFinal.JetpackFuel <= 0)
        {
            PlayerControllerFinal.OutOfJetpack = true;
            return new StateInAir(PlayerControllerFinal);
        }
        
        //Wall sate
        if (PlayerControllerFinal.IsOnLeftWall || PlayerControllerFinal.IsOnRightWall && _canCatch)
        {
            return new StateWallCatch(PlayerControllerFinal);
        }
        
        return null;
    }

    private void DoJetpack()
    {
        PlayerControllerFinal.IsInJetpack = true;
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        if (PlayerControllerFinal.IsOnLeftWall)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2 (Time.deltaTime * 40000, JetpackForce * Time.deltaTime)); 
        }

        if (PlayerControllerFinal.IsOnRightWall)
        {
            PlayerControllerFinal.Rb.AddForce(new Vector2 (Time.deltaTime * - 40000, JetpackForce * Time.deltaTime)); 
        }
    }

    private void JetpackHorizontalMobility()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime * 40000, JetpackForce * Time.deltaTime));
    }
}
