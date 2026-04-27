using UnityEngine;

public class StartState : IGameState
{
    public void Enter()
    {
        Debug.Log("Estado: START");
        //GameManager.Instance.StartGame()
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
