using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public GameStateMachine StateMachine { get; private set; }
    public WordSystem WordSystem { get; private set; }
    public LifeSystem LifeSystem { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);   
        }

        Instance = this;

        InitializeSystems();
    }

    private void Start()
    {
        StateMachine.ChangeState(new StartState());
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void InitializeSystems()
    {
        WordSystem = new WordSystem();
        LifeSystem = new LifeSystem(); 

        StateMachine = new GameStateMachine();

        SuscribeToEvents();
    }

    private void SuscribeToEvents()
    {
        EventBus.OnGameWon += OnGameWon;
        EventBus.OnGameLost += OnGameLost;
    }

    public void StartGame()
    {
        LifeSystem.Reset();
        WordSystem.SetWord("UNITY");

        StateMachine.ChangeState(new PlayingState());
    }

    public void OnGameWon()
    {
        StateMachine.ChangeState(new WinState());
    }

    public void OnGameLost()
    {
        StateMachine.ChangeState(new LoseState());
    }
}
