using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.AI;
public class LazerPointer : MonoBehaviour
{
    [SerializeField] LineRenderer lazer;

    [SerializeField] Transform initialPos;


    [SerializeField] GameObject spherePos;

    [SerializeField] AIGeneraMovement bunny;
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;
    void Start()
    {
        TryInitialize();
    }
    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {

        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

        }

    }
    private void FixedUpdate()
    {




        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if (gripValue > .01f)
            {
                lazer.enabled = true;
                lazer.SetPosition(0, initialPos.position);

                RaycastHit hit1;

                if (Physics.Raycast(initialPos.position, initialPos.TransformDirection(Vector3.forward), out hit1, 100))
                {
                    
                    Debug.DrawRay(initialPos.position, initialPos.TransformDirection(Vector3.forward) * hit1.distance, Color.yellow);
                    lazer.SetPosition(1, hit1.point);
                    Debug.Log(hit1.collider.name);
                    spherePos.transform.position = hit1.point;

                    bunny.AssignMovementTask(spherePos.transform.position);
                    /* NavMeshHit navMeshHit;

                     if (NavMesh.SamplePosition(hit1.point, out navMeshHit, .5f, 1))
                     {

                         bunny.AssignMovementTask(navMeshHit.position);



                     }

     */
                }
                else
                {
                    Debug.DrawRay(initialPos.position, initialPos.TransformDirection(Vector3.forward) * 100, Color.white);
                    lazer.enabled= false;
                }

            }
        }
    }

}
