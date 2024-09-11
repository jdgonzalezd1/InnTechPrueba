using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter Instance
    {
        get; private set;
    }

    [SerializeField]
    private TextMeshProUGUI cylinderCount;

    [SerializeField]
    private TextMeshProUGUI sphereCount;

    [SerializeField]
    private TextMeshProUGUI boxCount;

    [SerializeField]
    private TextMeshProUGUI totalCount;

    private int cylinders;

    private int spheres;

    private int boxes;

    private int remainingItems;

    public int TotalItems
    {
        get; private set;
    }

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
        UpdateCount();
        TotalItems = 0;
    }

    private void UpdateCount()
    {
        cylinderCount.text = $"{cylinders}";
        sphereCount.text = $"{spheres}";
        boxCount.text = $"{boxes}";
        totalCount.text = $"Objetos restantes: {remainingItems}";
        GameManager.Instance.UpdateGameStatus();
    }

    public void AddCount(ObjectType type)
    {
        switch (type)
        {
            case ObjectType.Cylinder:
                cylinders++;
                break;

            case ObjectType.Sphere:
                spheres++;
                break;

            case ObjectType.Box:
                boxes++;
                break;
        }
        TotalItems++;
        remainingItems--;

        UpdateCount();
    }

    public void TotalCount(int total)
    {
        remainingItems = total;        
    }



}
