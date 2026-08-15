using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _errorText;

    private void OnEnable()
    {
        EventBus.OnErrorChanged += OnErrorChanged;
    }

    private void OnDisable()
    {
        EventBus.OnErrorChanged -= OnErrorChanged;
    }

    private void Start()
    {
        UpdateErrorDisplay();
    }

    private void OnErrorChanged(int errors)
    {
        UpdateErrorDisplay();
    }

    private void UpdateErrorDisplay()
    {
        LifeSystem lifeSystem = GameManager.Instance.LifeSystem;

        _errorText.text =
            $"Errores: {lifeSystem.Errors}/{lifeSystem.MaxErrors}";
    }
}