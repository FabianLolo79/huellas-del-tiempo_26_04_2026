using UnityEngine;

public class LoseState : IGameState
{
    public void Enter()
    {
        Debug.Log("Estado: Lose");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
