using UnityEngine;

public class LifeSystem 
{
 
    private int _errors = 0;
    private int _maxErrors = 8;

    public LifeSystem()
    {
        EventBus.OnWrongLetter += OnWrongLetter;
    }

    private void OnWrongLetter(char letter)
    {
        _errors ++;
        Debug.Log($"Error {_errors}/{_maxErrors}");

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
