using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum MoonPhase
{ NewMoon, WaxingCrescent, FirstQuarter, WaxingGibbous, FullMoon, WaningGibbous, ThirdQuarter, WaningCrescent
}

public class MoonPhaseController : MonoBehaviour
{
    [Header ("Phase Mangement")]
    public Renderer moonRend;

    public MoonPhase moonPhase = MoonPhase.NewMoon;

    [Range(-1,1)]
    [Tooltip("Move the oval mask left or right on the moon texture")]
    public float maskOffset;
    public bool oppositePhase;
    [Tooltip("Set to true to switch to the next phase in the moon phase cycle.")]
    public bool nextPhase;

    [Header("Color")]
    public Color32 moonColor = Color.white; 
    [Tooltip("Adjust the color intensity of the image, helpful for kinda visible moon")]
    [Range(0,3)]
    public float HDRIntensity;
    private float colorIntensity;
    [Range(0,1)]
    [Tooltip("Change transparency of the moon. 0 = fully transparent, 1 = non-transparent")]
    public float texAlpha = 1;

    [Header("Mask Shape")]
    [Range(0, 30)]
    public float maskShape = 1;

    private int numberOfMoonPhases, currentEnum;



    // Start is called before the first frame update
    void Start()
    {
        moonRend = this.GetComponent<Renderer>();
        maskShape = 1f;

        numberOfMoonPhases = System.Enum.GetValues(typeof(MoonPhase)).Length;
    }

    // Update is called once per frame
    void Update()
    {
        colorIntensity = HDRIntensity / 200;

        ShaderUpdate();
        MoonPhaseManager();

    }

    public void MoonPhaseManager()
    {
        ChangePhase();
        switch (moonPhase)
        {
            case MoonPhase.NewMoon:
                maskOffset = 0f;
                maskShape = 1f;
                oppositePhase = true;
                break;
            case MoonPhase.WaxingCrescent:
                maskOffset = 0.25f;
                maskShape = 1f;
                oppositePhase = true;
                break;
            case MoonPhase.FirstQuarter:
                maskOffset = 0.5f;
                maskShape = 30f;
                oppositePhase = true;
                break;
            case MoonPhase.WaxingGibbous:
                maskOffset = -0.15f;
                maskShape = 1f;
                oppositePhase = false;
                break;
            case MoonPhase.FullMoon:
                maskOffset = 0f;
                maskShape = 1f;
                oppositePhase = false;
                break;
            case MoonPhase.WaningGibbous:
                maskOffset = .15f;
                maskShape = 1f;
                oppositePhase = false;
                break;
            case MoonPhase.ThirdQuarter:
                maskOffset = .5f;
                maskShape = 30f;
                oppositePhase = false;
                break;
            case MoonPhase.WaningCrescent:
                maskOffset = -.25f;
                maskShape = 1f;
                oppositePhase = true;
                break;
            default:
                break;
        }
    }

    public void ShaderUpdate()
    {
        moonRend.material.SetVector("_MaskOffset", new Vector2 (maskOffset, 0));
        moonRend.material.SetVector("_CrescentShape", new Vector2 (1, maskShape));
        moonRend.material.SetFloat("_Alpha", texAlpha);
        moonRend.material.SetFloat("_OppositeSwap", oppositePhase ? 1.0f : 0.0f);
        moonRend.material.SetVector("_MainColor", new Vector4 (moonColor.r,
            moonColor.g, moonColor.b, moonColor.a) * colorIntensity);
    }

    public void ChangePhase()
    {
        currentEnum = (int)moonPhase;
        if(currentEnum >= numberOfMoonPhases)
        {
            currentEnum = 0;
        }

        // Change this to a bool
        if (nextPhase)
        {
            currentEnum++;
            nextPhase = false;
        }
        moonPhase = (MoonPhase) currentEnum;
    }

    private void DebugLog()
    {
        if (moonRend == null)
            Debug.LogError("Please use a valid renderer component compatible with this script.");
    }
}
