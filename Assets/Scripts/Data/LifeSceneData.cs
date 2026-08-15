using UnityEngine;

[CreateAssetMenu(fileName = "LifeSceneData", menuName = "Huellas del Tiempo/Life Scene Data")]
public class LifeSceneData : ScriptableObject
{
    [Header("Información")]
    [SerializeField] private int _errorNumber;
    [SerializeField] private string _title;

    [Header("Visual")]
    [SerializeField] private Sprite _image;

    [Header("Narrativa")]
    [TextArea]
    [SerializeField] private string _description;

    public int ErrorNumber => _errorNumber;
    public string Title => _title;
    public Sprite Image => _image;
    public string Description => _description;
}
