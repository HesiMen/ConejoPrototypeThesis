using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSkyBoxRotation : MonoBehaviour
{
    public Material skybox;
    private float rotation;
    public float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        skybox = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        RotateSkyBox();
    }

    public void RotateSkyBox()
    {
        rotation += Time.deltaTime * rotationSpeed;
        skybox.SetFloat("_Rotation", rotation);
    }
}
