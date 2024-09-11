using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int ObjectsOnScene;

    private void Start()
    {
        ObjectsOnScene = FindObjectsByType<InteractableObject>(FindObjectsSortMode.None).Length;
    }

    public void UpdateGameStatus()
    {

    }
}
