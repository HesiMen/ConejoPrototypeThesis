using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CraftingComponent : MonoBehaviour
{
    [SerializeField]
    CraftingManager manager;
    [SerializeField]
    List<CraftableItem> craftableItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttemptCraft()
    {
        // Loop through list of craftable items and check if this + the other component are both activated
        if (manager.activatedComponents.Contains(this))
        {
            foreach (CraftableItem item in craftableItems)
            {
                if(this == item.componentOne || this == item.componentTwo)
                {
                    if (manager.activatedComponents.Contains(item.componentOne) && manager.activatedComponents.Contains(item.componentTwo))
                    {
                        manager.CraftItem(item.componentOne, item.componentTwo, item);
                    }
                }
            }
        }
    }

}
