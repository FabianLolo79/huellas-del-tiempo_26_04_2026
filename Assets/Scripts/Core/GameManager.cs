using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public GameStateMachine StateMachine { get; private set; }
    public WordSystem WordSystem { get; private set; }
    public LifeSystem LifeSystem { get; private set; }
    public LifeSceneDatabase LifeSceneDatabase { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
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

        LifeSceneDatabase = FindAnyObjectByType<LifeSceneDatabase>();

        StateMachine = new GameStateMachine();

        SuscribeToEvents();
    }

    private void SuscribeToEvents()
    {
        EventBus.OnGameWon += OnGameWon;
        EventBus.OnGameLost += OnGameLost;
        EventBus.OnLifeTransition += OnLifeTransition;
    }

    public void StartGame()
    {
        LifeSystem.Reset();
        WordSystem.SetWord("UNITY");

        StateMachine.ChangeState(new PlayingState());
    }

    private void OnGameWon()
    {
        StateMachine.ChangeState(new WinState());
    }

    private void OnGameLost()
    {
        StateMachine.ChangeState(new LoseState());
    }

    private void OnLifeTransition()
    {
        StateMachine.ChangeState(new LifeTransitionState());
    }
}
