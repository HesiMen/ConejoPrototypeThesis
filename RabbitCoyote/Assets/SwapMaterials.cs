using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterials : MonoBehaviour
{
    public List<Material> materials;
    public int materialSwapIndex;

    private Renderer[] childrenRend;

    private void Start() 
    {
        childrenRend = GetComponentsInChildren<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        MaterialSwap();
    }

    public void MaterialSwap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (materialSwapIndex >= materials.Count - 1)
            {
                materialSwapIndex = 0;
            }
            else
            {
                materialSwapIndex++;
            }
            
            foreach(Renderer rend in childrenRend)
            {
                rend.material = materials[materialSwapIndex];
            }
        }
    }
}
