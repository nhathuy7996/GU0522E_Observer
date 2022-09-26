using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
  
        Observer.Instant.AddObserver(Observer.ADD_GOLD, showGoldRise);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showGoldRise(object data)
    {
        Debug.LogError("+"+(int)data);
    }
}
