using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionList : MonoBehaviour
{
    //Collection of Collectible objects
    public List<GameObject> collectibles;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            collectibles.Add(child.gameObject);
        }
        
    }
}
