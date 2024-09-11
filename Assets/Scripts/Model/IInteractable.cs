using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInteractable
{    
    bool IsInteracting { get; }

    void OnInteractionEnabled();

    void OnInteractionDisabled();
    
}
