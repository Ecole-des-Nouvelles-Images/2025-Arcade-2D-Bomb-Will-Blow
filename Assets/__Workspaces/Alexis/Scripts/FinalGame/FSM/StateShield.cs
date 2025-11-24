using UnityEngine;

public class StateShield : BaseState
{
    public StateShield(PlayerControllerFinal playerControllerFinal) : base(playerControllerFinal) { }
    
    public override void OnEnter()
    {
        PlayerControllerFinal.UseShield = true;
        DoShield();
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        PlayerControllerFinal.UseShield = false;
    }

    public override BaseState NextState()
    {
        //state à faire : wall - air - jetpack - idle - walk
        return NextState();
    }

    private void DoShield()
    {
        PlayerControllerFinal.ShieldEffect.SetActive(true);
    }
}
