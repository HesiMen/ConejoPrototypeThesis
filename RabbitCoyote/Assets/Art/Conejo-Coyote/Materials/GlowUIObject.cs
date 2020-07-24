using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GlowUI", menuName = "Custom/GlowUI")]
public class GlowUIObject : ScriptableObject
{
    [Range(0,1)]
    public float lerpActuatorPosition = 0;
}
