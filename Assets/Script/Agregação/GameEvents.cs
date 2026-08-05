using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    private void Awake() => Instance = this;

    public event Action<GameObject> OnAscentReproduceEnter;
    public void AscentReproduceEnter(GameObject id) => OnAscentReproduceEnter?.Invoke(id);
    public event Action<GameObject> OnAscentReproduceExit;
    public void AscentReproduceExit(GameObject id) => OnAscentReproduceExit?.Invoke(id);
}
