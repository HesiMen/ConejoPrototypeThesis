using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloudManager : MonoBehaviour
{
    [Header("Particle Systems")]
    public ParticleSystem rain;
    public ParticleSystem clouds;
    public ParticleSystem ripples;

    [Header("Activate Play")]
    public bool playRain;
    public bool playClouds;
    public bool playRipples;

    [Header("Rain Settings")]
    [Range(0, 1000)]
    [SerializeField] private int rainParticleNum;
    [Range(0,2)]
    [SerializeField] private float rainSimSpeed;
    [SerializeField] private Vector3 rainVelocityOverLifetime;

    [Header("Cloud Settings")]
    [Range(0,20)]
    [SerializeField] private int cloudParticleNum;
    [Range(0,10)]
    [SerializeField] private float cloudSimSpeed;
    [SerializeField] private Color32 cloudColor;

    [Range(0,3)]
    public float HDRIntensity;
    private float colorIntensity;
    private Renderer cloudRend;

    


    // Start is called before the first frame update
    void Start()
    {
        if (rain == null || clouds == null || ripples == null)
            Debug.LogError("Please set a particle system for all particle system elements.");
        
        if(clouds != null)
            cloudRend = clouds.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        colorIntensity = HDRIntensity / 200;

        PlayRain();
        PlayClouds();
        PlayRipples();

        //Settings Methods
        RainSettings();
        CloudSettings();
    }

// Rain
    public void PlayRain()
    {
        if (playRain && rain.isStopped)
            rain.Play();
        
        if (!playRain && rain.isPlaying)
            rain.Stop();
    }

    public void RainSettings()
    {
        if (rain.isPlaying)
        {
            //Particle Rate Control
            var rainEmission = rain.emission;
            rainEmission.rateOverTime = rainParticleNum;

            //Simulation Speed
            var rainSpeed = rain.main;
            rainSpeed.simulationSpeed = rainSimSpeed;

            // Velocity over liftime
            var rainVel = rain.velocityOverLifetime;
                rainVel.x = rainVelocityOverLifetime.x;
                rainVel.y = rainVelocityOverLifetime.y;
                rainVel.z = rainVelocityOverLifetime.z;
        }
    }


// Clouds
    public void PlayClouds()
    {
        if (playClouds && clouds.isStopped)
            clouds.Play();

        if (!playClouds && clouds.isPlaying)
            clouds.Stop();
    }

    public void CloudSettings()
    {
        if (clouds.isPlaying)
        {
        //Particle Rate Control
            var cloudEmission = clouds.emission;
            cloudEmission.rateOverTime = cloudParticleNum;

        //Simulation Speed
            var cloudSpeed = clouds.main;
            cloudSpeed.simulationSpeed = cloudSimSpeed;


        // Cloud Color
            cloudRend.material.SetColor("_BaseColor", new Vector4 (cloudColor.r, cloudColor.g, cloudColor.b, cloudColor.a) * colorIntensity);
        }
    }

    public void PlayRipples()
    {
        if (playRipples && ripples.isStopped)
            ripples.Play();

        if (!playRipples && ripples.isPlaying)
            ripples.Stop();
    }
}
