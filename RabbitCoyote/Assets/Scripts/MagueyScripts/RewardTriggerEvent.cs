using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardTriggerEvent : BeatEvent
{
    public Transform snapPlace;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<AgaveObject>() != null && other.GetComponentInParent<AgaveObject>().agaveObject == AgaveObject.AgaveObjectsInteractables.SmallRock)
        {
            Debug.Log("SmallRockEvent");
            other.GetComponent<XROffsetGrabInteractable>().trackPosition = false;
            other.GetComponent<XROffsetGrabInteractable>().trackRotation = false;
          
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Collider>().enabled = false;
            other.transform.position = snapPlace.position;
            other.transform.rotation = snapPlace.rotation;

            other.GetComponent<XROffsetGrabInteractable>().enabled = false;



            TaskDone();
        }
    }
}
