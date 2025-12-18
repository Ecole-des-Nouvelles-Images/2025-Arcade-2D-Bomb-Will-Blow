using __Workspaces.Alexis.Scripts.FinalGame;
using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerController playerController) : base(playerController) { }

    private float JetpackForce = 25000;
    
    private float _timeBeforeCatch;
    private bool _canCatch;
    
    public override void OnEnter()
    {
        Debug.Log("State Jetpack Entry");
        PlayerController.PlayerAnimator.SetBool("Jetpack", true);
        PlayerController.Rb.linearVelocity = Vector2.zero;
        PlayerController.IsInJetpack = true;
        DoJetpack();
    }

    public override void OnUpdate()
    {
        PlayerController.JetpackCurrent -= Time.deltaTime;
        if (PlayerController.JetpackCurrent > 0)
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
        PlayerController.PlayerAnimator.SetBool("Jetpack", false);
        PlayerController.IsInJetpack = false;
    }

    public override BaseState NextState()
    {
        //InAir state
        if (PlayerController.JetpackCurrent <= 0)
        {
            PlayerController.OutOfJetpack = true;
            return new StateInAir(PlayerController);
        }
        
        //Wall sate
        if (PlayerController.IsOnLeftWall || PlayerController.IsOnRightWall && _canCatch)
        {
            return new StateWallCatch(PlayerController);
        }
        
        return null;
    }

    private void DoJetpack()
    {
        PlayerController.IsInJetpack = true;
        PlayerController.Rb.linearVelocity = Vector2.zero;
        if (PlayerController.IsOnLeftWall)
        {
            PlayerController.Rb.AddForce(new Vector2 (Time.deltaTime * 40000, PlayerController.PlayerData.JetpackForce * Time.deltaTime)); 
        }

        if (PlayerController.IsOnRightWall)
        {
            PlayerController.Rb.AddForce(new Vector2 (Time.deltaTime * - 40000, PlayerController.PlayerData.JetpackForce * Time.deltaTime)); 
        }
    }

    private void JetpackHorizontalMobility()
    {
        PlayerController.Rb.linearVelocity = Vector2.zero;
        PlayerController.Rb.AddForce(new Vector2 (PlayerController.Move.x * Time.deltaTime * 40000, PlayerController.PlayerData.JetpackForce * Time.deltaTime));
    }
}
