using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get; private set;
    }

    private int ObjectsOnScene;

    public UnityEvent gameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else 
        { 
            Instance = this;
        }
    }

    private void Start()
    {
        ObjectsOnScene = FindObjectsByType<InteractableObject>(FindObjectsSortMode.None).Length;
        Counter.Instance.TotalCount(ObjectsOnScene);
    }

    public void UpdateGameStatus()
    {
        if (Counter.Instance.TotalItems == ObjectsOnScene)
        {
            gameOver.Invoke();
        }
    }
}
