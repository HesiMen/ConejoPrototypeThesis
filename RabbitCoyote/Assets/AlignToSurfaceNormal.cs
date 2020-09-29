using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToSurfaceNormal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            Debug.Log("Did Hit");
        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }
}
