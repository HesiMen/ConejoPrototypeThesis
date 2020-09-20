using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightManager : MonoBehaviour
{

    public Light fireLight;

    [SerializeField]
    private float minIntensity;

    [SerializeField]
    private float maxIntensity;

    [Tooltip("Flicker Rate is defined as the number of frames that must pass in order to call the function that activates the flicker. For example if you put 10 into the field, every 10 frames the RandomIntensity function which causes the flicker will activate.")]
    [SerializeField]
    private int flickerRate;

    // Update is called once per frame
    void FixedUpdate()
    {
        RandomIntensity();
    }

    private void RandomIntensity()
    {
        if (Time.frameCount % flickerRate == 0)
            fireLight.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
