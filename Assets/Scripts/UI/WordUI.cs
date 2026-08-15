using TMPro;
using UnityEngine;

public class WordUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _wordText;

    private void OnEnable()
    {
        EventBus.OnCorrectLetter += OnCorrectLetter;
    }

    private void Start()
    {
        UpdateWordDisplay();
    }

    private void OnCorrectLetter(char letter)
    {
        UpdateWordDisplay();
    }

    private void UpdateWordDisplay()
    {
        string word = GameManager.Instance.WordSystem.CurrentWord;

        if (string.IsNullOrEmpty(word)) return;

        string display = "";

        foreach (char letter in word)
        {
            if (IsLetterGuessed(letter))
            {
                display += letter + " ";
            }
            else
            {
                display += "_ ";
            }
        }

        _wordText.text = display.TrimEnd();
    }

    private bool IsLetterGuessed(char letter)
    {
        return GameManager.Instance.WordSystem.IsLetterGuessed(letter);
    }

    private void OnDisable()
    {
        EventBus.OnCorrectLetter -= OnCorrectLetter;
    }
}
