using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class RotateObject : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;




    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        // Gets mouse positions and applies rotation to the object with this script
        if (Input.GetMouseButton(1))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            transform.Rotate(transform.up, -Vector3.Dot(mPosDelta * rotationSpeed, Camera.main.transform.right), Space.World);
        }

        mPrevPos = Input.mousePosition;
    }
}
