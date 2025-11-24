using UnityEngine;

public class StateJetpack : BaseState
{
    public StateJetpack(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }

    private float JetpackForce = 5;
    
    public override void OnEnter()
    {
        PlayerControllerFinal.Rb.linearVelocity = Vector2.zero;
        //Animator update
        DoJetpack();
    }

    public override void OnUpdate()
    {
        PlayerControllerFinal.JetpackFuel -= Time.deltaTime;
        if (PlayerControllerFinal.JetpackFuel <= 0)
        {
            PlayerControllerFinal.IsInJetpack = false;
        }
    }

    public override void OnExit()
    {
        
    }

    public override BaseState NextState()
    {
        if (!PlayerControllerFinal.IsInJetpack)
        {
            //Changer l'état retourné par "InAir" lorsqu'il sera créé.
            return new StateIdle(PlayerControllerFinal);
        }
        return NextState();
    }

    private void DoJetpack()
    {
        PlayerControllerFinal.IsInJetpack = true;
        PlayerControllerFinal.Rb.AddForce(new Vector2 (PlayerControllerFinal.Move.x * Time.deltaTime, JetpackForce), ForceMode2D.Force); 
    }
}
