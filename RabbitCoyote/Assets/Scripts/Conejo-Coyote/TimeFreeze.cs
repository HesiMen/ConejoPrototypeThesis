using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreeze : MonoBehaviour
{
  public void StopTime()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }
}
