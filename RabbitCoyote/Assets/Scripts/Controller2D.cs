﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] AIGeneraMovement bunny;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        //Sends Raycast on click to set waypoint for attached animal AI
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)) {
            Transform objectHit = hit.transform;

            bunny.AssignMovementTask(hit.point);
        }
    }
}
