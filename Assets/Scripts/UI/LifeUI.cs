using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private Image _lifeImage;

    private void OnEnable()
    {
        EventBus.OnErrorChanged += OnErrorChanged;
        EventBus.OnLifeSceneChanged += OnLifeSceneChanged;
    }

    private void Start()
    {
        UpdateErrorDisplay();
    }

    private void OnErrorChanged(int errors)
    {
        UpdateErrorDisplay();
    }

    private void OnLifeSceneChanged(LifeSceneData scene)
    {
        _lifeImage.sprite = scene.Image;
    }

    private void UpdateErrorDisplay()
    {
        LifeSystem lifeSystem = GameManager.Instance.LifeSystem;

        _errorText.text =
            $"Errores: {lifeSystem.Errors}/{lifeSystem.MaxErrors}";
    }

    private void OnDisable()
    {
        EventBus.OnErrorChanged -= OnErrorChanged;
        EventBus.OnLifeSceneChanged -= OnLifeSceneChanged;

    }

}