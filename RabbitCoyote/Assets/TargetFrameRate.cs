using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    public int frameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameRate;
    }

}
