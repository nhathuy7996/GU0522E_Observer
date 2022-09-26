using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observer : MonoBehaviour
{

    private static Observer _instant;
    public static Observer Instant => _instant;

    Dictionary<string, HashSet<Action<object>>> ListObservers =
        new Dictionary<string, HashSet<Action<object>>>();

    public const string ADD_GOLD = "ADD_GOLD";


    private void Awake()
    {

        if(_instant == null)
        {
            Observer[] objs = FindObjectsOfType<Observer>();
            _instant = objs[0];
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void AddObserver(string name, Action<object> action)
    {

        HashSet<Action<object>> listActions = new HashSet<Action<object>>();
        if (!ListObservers.TryGetValue(name, out listActions))
        {
            listActions = new HashSet<Action<object>>();
            listActions.Add(action);
            ListObservers.TryAdd<string, HashSet<Action<object>>>(name, listActions);
            return;
        }

        listActions.Add(action);
    }

    public void RemoveObserver(string name, Action<object> action)
    {
        HashSet<Action<object>> listActions = new HashSet<Action<object>>();
        if (!ListObservers.TryGetValue(name, out listActions))
        {
           return;
        }

        if (listActions.Contains(action))
            listActions.Remove(action);
    }

    public void Notify(string name, object data = null)
    {
        HashSet<Action<object>> actions =  new HashSet<Action<object>>();
        ListObservers.TryGetValue(name, out actions);

        foreach (Action<object> a in actions)
        {
            a.Invoke(data);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
