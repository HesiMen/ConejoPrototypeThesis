using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastTest : MonoBehaviour
{
    public Transform initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.gameObject.GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
                RaycastHit hit1;

                if (Physics.Raycast(initialPos.position, transform.TransformDirection(Vector3.forward), out hit1, 100))
                {
                    
                    Debug.DrawRay(initialPos.position, initialPos.TransformDirection(Vector3.forward) * hit1.distance, Color.green);
                    Debug.Log(hit1.collider.gameObject.layer);
                    /* NavMeshHit navMeshHit;

                     if (NavMesh.SamplePosition(hit1.point, out navMeshHit, .5f, 1))
                     {

                         bunny.AssignMovementTask(navMeshHit.position);



                     }

     */
                }
                else
                {
                    Debug.DrawRay(initialPos.position, initialPos.TransformDirection(Vector3.forward) * 1000, Color.red);
                }

    }
}
