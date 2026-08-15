using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter()
    {
        Debug.Log("[PlayingState] Estado: PLAYING");

    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
