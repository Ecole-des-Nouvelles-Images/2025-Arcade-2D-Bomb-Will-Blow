using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerController playerController) : base(playerController) { }

    private float JetpackForce = 25000;
    
    private float _timeBeforeCatch;
    private bool _canCatch;
    
    public override void OnEnter()
    {
        
        PlayerController.PlayerAudio.PlayOneShot(PlayerController.JetpackSounds[Random.Range(0, PlayerController.JetpackSounds.Count)]);
        PlayerController.PlayerAnimator.SetBool("Jetpack", true);
        Object.Instantiate(PlayerController.JetpackEffect, new Vector2(PlayerController.transform.position.x + 1.3f , PlayerController.transform.position.y - 0.8f), Quaternion.identity, PlayerController.transform);
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
        
        if (_timeBeforeCatch < 0.3)
        {
            _timeBeforeCatch += Time.deltaTime;
            _canCatch = false;
        }
            
        if (_timeBeforeCatch >= 0.3)
        {
            _canCatch = true;
        }
    }

    public override void OnExit()
    {
        PlayerController.PlayerAudio.Stop();
        PlayerController.PlayerAnimator.SetBool("Jetpack", false);
        PlayerController.IsInJetpack = false;
    }

    public override BaseState NextState()
    {
        //Death state
        if (!PlayerController.Alive) {
            return new StateDeath(PlayerController);
        }
        
        //InAir state
        if (PlayerController.JetpackCurrent <= 0 || PlayerController.UseJetpack && _canCatch)
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

    //Méthode qui décroche le joueur du mur au lancement du jetpack
    private void DoJetpack()
    {
        PlayerController.IsInJetpack = true;
        PlayerController.Rb.linearVelocity = Vector2.zero;
        if (PlayerController.IsOnLeftWall)
        {
            PlayerController.Rb.AddForce(new Vector2 (Time.deltaTime * 100000, PlayerController.PlayerData.JetpackForce * Time.deltaTime)); 
        }

        if (PlayerController.IsOnRightWall)
        {
            PlayerController.Rb.AddForce(new Vector2 (Time.deltaTime * - 100000, PlayerController.PlayerData.JetpackForce * Time.deltaTime)); 
        }
    }

    //Méthode qui permet au joueur de se déplacer pendant le jetpack
    private void JetpackHorizontalMobility()
    {
        PlayerController.Rb.linearVelocity = Vector2.zero;
        PlayerController.Rb.AddForce(new Vector2 (PlayerController.Move.x * Time.deltaTime * 40000, PlayerController.PlayerData.JetpackForce * Time.deltaTime));
    }
}
