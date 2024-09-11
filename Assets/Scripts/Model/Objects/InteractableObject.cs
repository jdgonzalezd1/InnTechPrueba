using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject InteractionIndicator;

    [SerializeField]
    private ObjectType type;

    public UnityEvent objectInteracted;

    public bool IsInteracting
    {
        get; private set;
    }

    public void OnInteractionDisabled()
    {
        print("GoodBye");
        InteractionIndicator.SetActive(false);
        IsInteracting = false;
    }

    public void OnInteractionEnabled()
    {
        print("Hello");
        InteractionIndicator.SetActive(true);
        IsInteracting = true;
    }

    public void PlayerTriggeredInteraction()
    {
        if (IsInteracting)
        {
            objectInteracted.Invoke();
            IsInteracting = false;
            Counter.Instance.AddCount(type);
            gameObject.SetActive(false);
        }
    }
}
