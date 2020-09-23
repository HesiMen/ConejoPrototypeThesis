using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MagueyTransparency))]
public class TransparencyCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MagueyTransparency myScript = (MagueyTransparency) target;

        if(GUILayout.Button("Reset Values"))
        {
            myScript.ResetValues();
        }
    }
}
