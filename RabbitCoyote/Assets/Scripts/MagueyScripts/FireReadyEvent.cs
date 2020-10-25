using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireReadyEvent : BeatEvent
{

    [SerializeField] Text countText;
    public List<AgaveObject> agaveObjects = new List<AgaveObject>();
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Count of AgaveObjects" + agaveObjects.Count);
        if (agaveObjects.Count > 3)
        {
            TaskDone();
            if (countText != null)
                countText.text = "Ready to make Fire";

        }
        else
        {
            if (other.GetComponentInParent<AgaveObject>() != null && other.GetComponentInParent<AgaveObject>().agaveObject == AgaveObject.AgaveObjectsInteractables.Sticks)
            {
                AgaveObject agaveObject = other.GetComponentInParent<AgaveObject>();

                if (!agaveObjects.Contains(agaveObject))//if is not in the list yet
                {
                    agaveObjects.Add(agaveObject);
                }
                if (countText != null)
                    countText.text = agaveObjects.Count.ToString();

            }
        }

        // 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<AgaveObject>() != null && other.GetComponentInParent<AgaveObject>().agaveObject == AgaveObject.AgaveObjectsInteractables.Sticks)
        {
            AgaveObject agaveObject = other.GetComponentInParent<AgaveObject>();

            if (agaveObjects.Contains(agaveObject))
            {
                agaveObjects.Remove(agaveObject);
            }

            if (countText != null)
                countText.text = agaveObjects.Count.ToString();
        }
    }
}
