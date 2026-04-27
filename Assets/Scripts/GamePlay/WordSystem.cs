using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordSystem 
{
    private string _currentWord;
    private HashSet<char> _guessedLetters = new HashSet<char>();

    public void SetWord(string word)
    {
        _currentWord = word.ToUpper();
        _guessedLetters.Clear();

        Debug.Log($"Palabra: {_currentWord}");
    }

    public void TryLetter(char letter)
    {
        letter = char.ToUpper(letter);

        if (_guessedLetters.Contains(letter)) return;
        
        _guessedLetters.Add(letter);

        if (_currentWord.Contains(letter))
        {
            EventBus.OnCorrectLetter?.Invoke(letter);

            if (IsWordComplete())
            {
                EventBus.OnGameWon?.Invoke();
            }
            else
            {
                EventBus.OnWrongLetter?.Invoke(letter);
            }
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
