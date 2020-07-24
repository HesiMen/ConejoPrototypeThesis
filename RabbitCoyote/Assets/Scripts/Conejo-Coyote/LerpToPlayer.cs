using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPlayer : MonoBehaviour
{
    [System.NonSerialized]
    public bool lerpState = false;

    public Transform targetLerpDestination;

    [Range (0,1)]
    public float lerpTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lerp2Player();
    }

    void Lerp2Player()
    {
        if (lerpState)
        {
            this.transform.position = new Vector3 (Mathf.Lerp(this.transform.position.x, this.targetLerpDestination.position.x, this.lerpTime),
                Mathf.Lerp(this.transform.position.y, this.targetLerpDestination.position.y, this.lerpTime), 
                Mathf.Lerp(this.transform.position.z, this.targetLerpDestination.position.z, this.lerpTime));

            this.lerpTime += 0.5f * Time.deltaTime;

            if (this.lerpTime > 1f)
            {
                this.lerpState = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
