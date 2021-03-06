﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public GameObject collectibleUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Collectible"))
        {
            other.gameObject.GetComponent<LerpToPlayer>().lerpState = true;
            collectibleUI.GetComponent<EnergyBraceletCounter>().plusEnergy = true;
        }
    }
}
