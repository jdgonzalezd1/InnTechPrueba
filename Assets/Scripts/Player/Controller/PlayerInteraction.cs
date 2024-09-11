using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

[RequireComponent(typeof(BoxCollider))]
public class PlayerInteraction : MonoBehaviour
{
    private InteractableObject currentInteraction;

    public UnityEvent playerInteractedWithObject;


    private void Update()
    {
        if (currentInteraction != null && InputManager.Instance.GetClick()) 
        {
            currentInteraction.PlayerTriggeredInteraction();
            print("Interacted");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentInteraction = other.GetComponent<InteractableObject>();

        if (currentInteraction != null)
        {
            currentInteraction.OnInteractionEnabled();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentInteraction != null) 
        {
            currentInteraction.OnInteractionDisabled();
        }

        currentInteraction = null;        
    }
}
