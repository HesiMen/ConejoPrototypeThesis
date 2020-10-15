using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField]
    public List<CraftingComponent> activatedComponents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateComponent(CraftingComponent component)
    {
        activatedComponents.Add(component);
    }
    public void DeactivateComponent(CraftingComponent component)
    {
        activatedComponents.Remove(component);
    }

    public void CraftItem(CraftingComponent componentOne, CraftingComponent componentTwo, CraftableItem item)
    {
        DeactivateComponent(componentOne);
        DeactivateComponent(componentTwo);
        item.gameObject.transform.position = componentOne.transform.position;
        item.gameObject.SetActive(true);
        componentOne.gameObject.SetActive(false);
        componentTwo.gameObject.SetActive(false);
    }
}
