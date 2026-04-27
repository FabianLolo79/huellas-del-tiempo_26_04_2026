using System;
using UnityEngine;

public class WinState : IGameState
{
    public void Enter()
    {
        Debug.Log("Estado: WIN");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
