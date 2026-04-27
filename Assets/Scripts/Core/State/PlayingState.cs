using JetBrains.Annotations;
using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter()
    {
        Debug.Log("Estado: PLAYING");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
