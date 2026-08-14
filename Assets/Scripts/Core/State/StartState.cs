using UnityEngine;

public class StartState : IGameState
{
    public void Enter()
    {
        Debug.Log("[StartState] Estado: START");
        GameManager.Instance.StartGame();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
