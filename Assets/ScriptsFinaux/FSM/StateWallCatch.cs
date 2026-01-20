using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class StateWallCatch : BaseState
{
    public StateWallCatch(PlayerController playerController) : base(playerController) { }

    private bool _canGetSpeed;
    private bool _activatesOnlyOnce;
    private float _timerBeforeFall;
    private float _timeToReach = 0.5f;

    public override void OnEnter()
    {
        //Passer en instatiate
        if (PlayerController.IsOnLeftWall)
        {
            PlayerController.LandingEffectLeftSide.SetActive(true);
        }
        if (PlayerController.IsOnRightWall)
        {
            PlayerController.LandingEffectRightSide.SetActive(true);
        }
        PlayerController.PlayerAnimator.SetBool("InAir", false);
        PlayerController.PlayerAnimator.SetBool("IdleWall", true);
        PlayerController.PlayerAnimator.SetBool("EndJump", false);
        PlayerController.Rb.gravityScale = 0;
        PlayerController.Rb.linearVelocity = Vector2.zero;
    }

    public override void OnUpdate()
    {
        PlayerController.CanWalk = false;
        
        if (!_activatesOnlyOnce)
        {
            _timerBeforeFall += Time.deltaTime;
        }
        
        if (_timerBeforeFall >= _timeToReach)
        {
            _canGetSpeed = true;
        }

        if (_canGetSpeed)
        {
            DoWallSlide();
        }
    }

    public override void OnExit()
    {
        PlayerController.LandingEffectRightSide.SetActive(false);
        PlayerController.LandingEffectLeftSide.SetActive(false);
        PlayerController.PlayerAnimator.SetBool("IdleWall", false);
        PlayerController.Rb.gravityScale = 1;
    }

    public override BaseState NextState()
    {
        //Death state
        if (!PlayerController.Alive) {
            return new StateDeath(PlayerController);
        }
        
        //Jump state
        if (PlayerController.Jump && PlayerController.Move.x != 0)
        {
            return new StateJump(PlayerController);
        }
        
        //Jetpack state
        if (PlayerController.UseJetpack)
        {
            PlayerController.PlayerAnimator.SetTrigger("JetpackEntry");
            return new StateJetpack(PlayerController);
        }
        
        //Shield state
        if (PlayerController.UseShield && PlayerController.CanShield)
        {
            return new StateShield(PlayerController);
        }
        
        //Dash state
        if (PlayerController.UseDash && PlayerController.CanDash)
        {
            PlayerController.PlayerAudio.PlayOneShot(PlayerController.DashSound);
            return new StateDash(PlayerController);
        }
        
        return null;
    }

    private void DoWallSlide()
    {
        PlayerController.Rb.AddForce(new Vector2(0, - PlayerController.PlayerData.SlideDownForce * Time.deltaTime));
        if (PlayerController.IsOnLeftWall) {
            Object.Instantiate(PlayerController.LeftSlideDust, new Vector3(PlayerController.transform.position.x - 0.7f, PlayerController.transform.position.y, PlayerController.transform.position.z), Quaternion.identity);
        }

        if (PlayerController.IsOnRightWall) {
            Object.Instantiate(PlayerController.RightSlideDust, new Vector3(PlayerController.transform.position.x + 0.5f, PlayerController.transform.position.y, PlayerController.transform.position.z), Quaternion.identity);
        }
        _canGetSpeed = false;
        _activatesOnlyOnce = false;
    }
}
