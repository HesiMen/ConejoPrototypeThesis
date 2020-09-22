using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlendMode
{
    Alpha,   // Old school alpha-blending mode, fresnel does not affect amount of transparency
    Premultiply, // Physically plausible transparency mode, implemented as alpha pre-multiply
    Additive,
    Multiply
}

public class MagueyTransparency : MonoBehaviour
{
    public GameObject maguey;
    public Renderer[] magueyRend;
    
    [SerializeField]
    private bool alphaToggle;

    public BlendMode blendMode;


    [SerializeField] [Range(-1,1)]
    private float objectAlpha;

    [SerializeField]
    private Color mainColor;

    
    // Start is called before the first frame update
    void Start()
    {
        magueyRend = maguey.GetComponentsInChildren<Renderer>();
        mainColor = magueyRend[0].material.GetColor("_Color");

        //renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectTransparency();
        //Debug.Log(magueyrend.material.renderQueue);
        //Debug.Log(magueyrend.material.GetColor("_Color"));
    }

    public void ObjectTransparency()
    {
        mainColor.a = objectAlpha;

        if (alphaToggle)
        {

            foreach(Renderer rend in magueyRend)
            {
                //blendMode = (BlendMode) rend.material.SetFloat("_Blend", alphaBlendType);

                // Specific Transparent Mode Settings
                switch (blendMode)
                {
                    case BlendMode.Alpha:
                        rend.material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                        rend.material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                        rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                        break;
                    case BlendMode.Premultiply:
                        rend.material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
                        rend.material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                        rend.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                        break;
                    case BlendMode.Additive:
                        rend.material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                        rend.material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.One);
                        rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                        break;
                    case BlendMode.Multiply:
                        rend.material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.DstColor);
                        rend.material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);
                        rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                        rend.material.EnableKeyword("_ALPHAMODULATE_ON");
                        break;
                }
                

                rend.material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                rend.material.SetColor("_Color", mainColor);
                rend.material.SetOverrideTag("RenderType", "Transparent");
                rend.material.SetInt("_ZWrite",1);

                rend.material.renderQueue += rend.material.HasProperty("_QueueOffset") ? (int) rend.material.GetFloat("_QueueOffset") : 0;
                rend.material.SetShaderPassEnabled("ShadowCaster", false);

            }
        }

        else
        {
            foreach(Renderer rend in magueyRend)
            {
                rend.material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;
                rend.material.SetOverrideTag("RenderType", "Opaque");

                rend.material.SetInt("_ZWrite",1);
            }
        }
    }
}
