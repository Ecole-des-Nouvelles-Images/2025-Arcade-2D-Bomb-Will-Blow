using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public abstract class BaseState
{
    protected PlayerController PlayerController;

    protected BaseState(PlayerController playerController)
    {
        PlayerController = playerController;
    }

    public abstract void OnEnter();
    
    public abstract void OnUpdate();
    
    public abstract void OnExit();
    
    public abstract BaseState NextState();
}
