using UnityEngine;

public abstract class BaseState
{
    protected PlayerControllerFinal PlayerControllerFinal;

    protected BaseState(PlayerControllerFinal playerControllerFinal)
    {
        PlayerControllerFinal = playerControllerFinal;
    }

    public abstract void OnEnter();
    
    public abstract void OnUpdate();
    
    public abstract void OnExit();
    
    public abstract BaseState NextState();
}
