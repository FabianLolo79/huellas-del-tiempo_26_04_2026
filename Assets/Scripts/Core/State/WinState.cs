using UnityEngine;

public class WinState : IGameState
{
    public void Enter()
    {
        Debug.Log("[WinState] Estado: WIN");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
