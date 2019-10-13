using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    private static Dictionary<string, UnityEvent> eventDict;
    static EventManager()
    {
        if (eventDict == null)
            eventDict = new Dictionary<string, UnityEvent>();
    }

    public static void Subscribe(string eventName, UnityAction listener)
    {
        UnityEvent @event = null;
        if (eventDict.TryGetValue(eventName, out @event))
        {
            @event.AddListener(listener);
        }
        else
        {
            @event = new UnityEvent();
            @event.AddListener(listener);
            eventDict.Add(eventName, @event);
        }
    }

    public static void Unsubscribe(string eventName, UnityAction listener)
    {
        UnityEvent @event = null;
        if (eventDict.TryGetValue(eventName, out @event))
        {
            @event.RemoveListener(listener);
        }
        else
            Debug.LogError($"Specified Event Name Couldn't Found: {eventName}");
    }

    public static void Trigger(string eventName)
    {
        UnityEvent @event = null;
        if (eventDict.TryGetValue(eventName, out @event))
        {
            @event.Invoke();
        }
        else
            Debug.LogError($"Specified Event Name Couldn't Found: {eventName}");
    }
}
