using UnityEngine;

public class LifeTransitionState : IGameState
{
    public void Enter()
    {
        Debug.Log("[LifeTransitionState] Estado: LIFE TRANSITION");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
