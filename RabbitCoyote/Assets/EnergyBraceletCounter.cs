using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBraceletCounter : MonoBehaviour
{
    public GameObject[] energyBlocks;
    private int lightBursts;
    Material m_Material;


    // Start is called before the first frame update
    void Start()
    {
        lightBursts = energyBlocks.Length;
        m_Material = GetComponentInChildren<Renderer>().material;
    }

    public bool addEnergy()
    {
        if (lightBursts < energyBlocks.Length)
        {
            lightBursts++;
            updateEnergyBraceletCounter();
            return true;
        }
        return false;
    }

    public bool loseEnergy()
    {
        lightBursts--;
        if (lightBursts > 0)
        {
            updateEnergyBraceletCounter();
            return false;
        }
        lightBursts = 0;
        updateEnergyBraceletCounter();
        return true;
    }

    private void updateEnergyBraceletCounter()
    {
        for (int i = 0; i < energyBlocks.Length; i++)
        {
            if (i < lightBursts)
            {
                energyBlocks[i].GetComponent<Renderer>().material.color = Color.white;
                //energyBlocks[i].SetActive(true);
            }
            else
            {
                energyBlocks[i].GetComponent<Renderer>().material.color = Color.grey;
                //m_Material.color = Color.gray;
                //energyBlocks[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            loseEnergy();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            addEnergy();
        }
    }

    
}
