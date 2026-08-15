using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current == null)
            return;

        foreach (KeyControl key in Keyboard.current.allKeys)
        {
            if (!key.wasPressedThisFrame)
                continue;

            char? letter = GetLetterFromKey(key);

            if (letter.HasValue)
            {
                GameManager.Instance.WordSystem.TryLetter(letter.Value);
            }
        }
    }

    private char? GetLetterFromKey(KeyControl key)
    {
        string keyName = key.name;

        if (keyName.Length != 1)
            return null;

        char letter = keyName[0];

        if (letter < 'a' || letter > 'z')
            return null;

        return char.ToUpper(letter);
    }
}
