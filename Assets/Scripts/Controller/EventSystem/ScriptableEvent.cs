using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableEvent : ScriptableObject
{
    private List<ScriptableEventListener> listeners = new List<ScriptableEventListener>();

    public void RegisterListener(ScriptableEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(ScriptableEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }
}
