using System.Collections.Generic;
using UnityEngine;

public class WordSystem 
{
    private string _currentWord;
    private HashSet<char> _guessedLetters = new HashSet<char>();

    public void SetWord(string word)
    {
        _currentWord = word.ToUpper();
        _guessedLetters.Clear();

        Debug.Log($"[WordSystem] Palabra: {_currentWord}");
    }

    public void TryLetter(char letter)
    {
        letter = char.ToUpper(letter);

        // la aletra ya fué utilizada
        if (_guessedLetters.Contains(letter))
        {
            EventBus.OnLetterAlreadyUsed?.Invoke(letter);
            return;
        }

        // Registramos la letra como utilizada
        _guessedLetters.Add(letter);
        EventBus.OnLetterUsed?.Invoke(letter);

        // comoprobamos si la letra pertenece a la palabra
        if (_currentWord.Contains(letter))
        {
            EventBus.OnCorrectLetter?.Invoke(letter);

            if (IsWordComplete())
            {
                EventBus.OnGameWon?.Invoke();
            }
        }
        else 
        {
            EventBus.OnWrongLetter?.Invoke(letter);
        }
    }

    private bool IsWordComplete()
    {
        foreach (char c in _currentWord)
        {
            if(!_guessedLetters.Contains(c))
                return false;
        }
        return true;
    }
}
