using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleManager : MonoBehaviour
{
    [Header("Sun & Moon")]
    [SerializeField] private GameObject sunMoonManager;
    [SerializeField] private float cycleLength;
    [SerializeField] private Vector3 sunMoonRotation;
    public int rotationCount;



    [Header("Stars")]
    [SerializeField] private ParticleSystem stars;
    [SerializeField] private Vector3 starRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (sunMoonManager == null)
            Debug.LogError("Missing game object reference on: " + this.name + "! Please add a reference to a game object.");

        if (stars == null)
            Debug.LogError("Missing particle system reference on: " + this.name + "! Please add a reference to a particle system.");
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateStars();
        RotateSunMoon();
    }

//==========================================================
// Sun & Moon Methods
    private void RotateSunMoon()
    {
        sunMoonManager.transform.Rotate(sunMoonRotation);
        //sunMoonManager.transform.Rotate(Mathf.Lerp(sunMoonRotation, ))

        if (sunMoonManager.transform.rotation.x % 360 == 0)
            rotationCount++;

        if (sunMoonManager.transform.rotation.x % 180 == 0)
            Debug.Log("Switch to night or day!");
    }

    private void SwapSunMoon()
    {

    }

//==========================================================



//==========================================================
// Star Methods
    private void RotateStars()
    {
        stars.transform.Rotate(starRotation);
    }
// End Star Methods
//==========================================================
}
