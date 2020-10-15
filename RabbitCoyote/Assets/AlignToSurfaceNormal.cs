using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToSurfaceNormal : MonoBehaviour
{
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private LayerMask maskLayer;
    //public int layerMask;
    private int bitMask;
    // Update is called once per frame
    void Update()
    {
        Ray rayDown = new Ray (this.transform.position + rayOffset, -this.transform.up);
        RaycastHit hitDown;

        if (Physics.Raycast(rayDown, out hitDown, 10, maskLayer))
        {
            Debug.DrawLine(rayDown.origin, hitDown.point, Color.green);

            this.transform.position = hitDown.point;
            
            //Debug.Log("Did Hit Down: " + hitDown.transform.name);
        }
        else
        {
            Debug.DrawLine(rayDown.origin, rayDown.origin + rayDown.direction * 10, Color.red);
            //Debug.Log("Did not Hit Down");
        }
    }
}
