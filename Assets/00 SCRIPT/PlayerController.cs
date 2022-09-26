using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    float _gold = 0;

    // Start is called before the first frame update
    void Start()
    {

        Observer.Instant.AddObserver(Observer.ADD_GOLD, addGold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void addGold(object newGold)
    {
        _gold += (int)newGold;
        Debug.LogError("current gold: " + _gold);
    }

}
