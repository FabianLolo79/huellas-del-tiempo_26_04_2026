using UnityEngine;

public class LifeSystem 
{
 
    private int _errors = 0;
    private int _maxErrors = 8;

    public int Errors => _errors;
    public int MaxErrors => _maxErrors;

    public LifeSystem()
    {
        EventBus.OnWrongLetter += OnWrongLetter;
    }

    private void OnWrongLetter(char letter)
    {
        _errors ++;

        EventBus.OnErrorChanged?.Invoke(_errors);

        Debug.Log($"[LifeSystem] Error {_errors}/{_maxErrors}");

        LifeSceneData scene = GameManager.Instance.LifeSceneDatabase.GetScene(_errors);

        if (scene != null)
        {
            Debug.Log($"[LifeSystem] Escena de vida {scene.Title}");
        }

        if (_errors >= _maxErrors)
        {
            EventBus.OnGameLost?.Invoke();
        }
    }

    public void Reset()
    {
        _errors = 0;
    }
 
}
