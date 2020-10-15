using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsHolePhysics : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<AgaveObject>() != null && other.gameObject.GetComponent<AgaveObject>().agaveObject == AgaveObject.AgaveObjectsInteractables.Seed)
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.layer = 14;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<AgaveObject>() != null &&  other.gameObject.GetComponent<AgaveObject>().agaveObject == AgaveObject.AgaveObjectsInteractables.Seed)
        {
            other.gameObject.layer = 13;
        }
    }
}
