using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireReadyEvent : BeatEvent
{
    private int stickCounter = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (stickCounter > 5)
        {
            if (whichTask == WhichTask.FiveSticks)
                TaskDone();
        }
        else
        {
            if (other.GetComponent<AgaveObject>().agaveObject == AgaveObject.AgaveObjectsInteractables.Sticks)
            {
                stickCounter += 1;
            }
        }
    }
}
