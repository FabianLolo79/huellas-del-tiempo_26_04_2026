using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardUI : MonoBehaviour
{
    [SerializeField] private Button _letterButtonPrefab;
    [SerializeField] private Transform[] _rows;

    private readonly string[] _keyboardRows =
    {
        "QWERTYUIOP",
        "ASDFGHJKLÑ",
        "ZXCVBNM"
    };

    private readonly Dictionary<char, Button> _letterButtons = new();

    private void OnEnable()
    {
        EventBus.OnLetterUsed += OnLetterUsed;
    }

    private void Start()
    {
        CreateKeyboard();
    }

    private void CreateKeyboard()
    {
        for (int rowIndex = 0; rowIndex < _keyboardRows.Length; rowIndex++)
        {
            string row = _keyboardRows[rowIndex];

            foreach (char letter in row)
            {
                CreateLetterButton(letter, _rows[rowIndex]);
            }
        }
    }

    private void CreateLetterButton(char letter, Transform row)
    {
        Button button = Instantiate(_letterButtonPrefab, row);

        button.name = $"LetterButton_{letter}";

        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

        if (buttonText != null)
        {
            buttonText.text = letter.ToString();
        }

        button.onClick.AddListener(() => OnLetterClicked(letter));

        _letterButtons.Add(letter, button);
    }

    private void OnLetterClicked(char letter) 
    {
        GameManager.Instance.WordSystem.TryLetter(letter);
    }

    private void OnLetterUsed(char letter)
    {
        if (_letterButtons.TryGetValue(letter, out Button button))
        {
            ColorBlock colors = button.colors;
            colors.disabledColor = Color.gray;
            button.colors = colors;

            button.interactable = false;
        }
    }

    private void OnDisable()
    {
        EventBus.OnLetterUsed -= OnLetterUsed;
    }
}