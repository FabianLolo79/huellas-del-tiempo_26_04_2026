using UnityEngine;

public class GameplayFeedback : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.OnCorrectLetter += OnCorrectLetter;
        EventBus.OnLetterAlreadyUsed += OnLetterAlreadyUsed;
    }

    private void OnCorrectLetter(char letter)
    {
        Debug.Log($"[GameplayFeedback] Letra correcta: {letter}");
    }

    private void OnLetterAlreadyUsed(char letter)
    {
        Debug.Log($"[GameplayFeedback] Letra ya utilizada: {letter}");

    }
    private void OnDisable()
    {
        EventBus.OnCorrectLetter -= OnCorrectLetter;
        EventBus.OnLetterAlreadyUsed -= OnLetterAlreadyUsed;
    }
}
