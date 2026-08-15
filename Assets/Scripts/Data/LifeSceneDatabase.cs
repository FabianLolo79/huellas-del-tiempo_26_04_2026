using System.Collections.Generic;
using UnityEngine;

public class LifeSceneDatabase : MonoBehaviour
{
    [SerializeField] private List<LifeSceneData> _lifeScenes;

    //private void Start()
    //{
    //    LifeSceneData scene = GetScene(1);

    //    if (scene != null)
    //    {
    //        Debug.Log($"[LifeSceneDatabase] Escena encontrada: {scene.Title}");
    //    }
    //}
    public LifeSceneData GetScene(int errorNumber)
    {
        foreach (LifeSceneData scene in _lifeScenes)
        {
            if (scene.ErrorNumber == errorNumber)
            {
                return scene;
            }
        }

        Debug.LogWarning($"[LifeSceneDataBase] No existe una escena para el error {errorNumber}.");
        
        return null;
    }
}
