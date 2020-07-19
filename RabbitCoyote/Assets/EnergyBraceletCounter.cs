using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBraceletCounter : MonoBehaviour
{
    public GameObject[] energyBlocks;
    private int lightBursts;
    Material m_Material;

    [SerializeField]
    // Variable for lerping
    [Range (0,1)]
    private float lerpActuator = 0.0f;

    // Is in charge of keeping index on energy blocks
    public int energyIndex;

    public float fadeRate;
    public bool plusEnergy, removeEnergy;


    // Start is called before the first frame update
    void Start()
    {
        lightBursts = energyBlocks.Length;
        m_Material = GetComponentInChildren<Renderer>().material;
        lerpActuator = this.gameObject.GetComponentInChildren<ShaderFillDataManger>().fill;
    }

    /*public bool addEnergy()
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
                //energyBlocks[i].GetComponent<Renderer>().material.color = Color.white;
                //energyBlocks[i].SetActive(true);
                energyBlocks[i].GetComponent<Renderer>().material.SetFloat("_FillHeight", Mathf.Lerp(0f, 1f, lerpActuator));
            }
            else
            {
                //energyBlocks[i].GetComponent<Renderer>().material.color = Color.grey;
                //m_Material.color = Color.gray;
                //energyBlocks[i].SetActive(false);
                energyBlocks[i].GetComponent<Renderer>().material.SetFloat("_FillHeight", Mathf.Lerp(1f, 0f, lerpActuator));

            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        LerpObjectEmission();
        //lerpActuator += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) && !removeEnergy)
        {
            //loseEnergy();
            if (energyIndex >= 0)
            {   
                //energyIndex--;
                removeEnergy = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && !plusEnergy)
        {
            //addEnergy();
            if (energyIndex >= 0)
            {   
                //energyIndex++;
                plusEnergy = true;
            }
        }
    }

    public void LerpObjectEmission()
    {
        energyBlocks[energyIndex].GetComponent<ShaderFillDataManger>().fill = lerpActuator;
        energyBlocks[energyIndex].GetComponent<Renderer>().material.SetFloat("_FillHeight", Mathf.Lerp(0f, 1f, lerpActuator));

        // Lower When Removing Energy
        if (removeEnergy)
        {
            plusEnergy = false;
            lerpActuator -= Time.deltaTime * fadeRate;
            if (lerpActuator < 0f)
            {
                if (energyIndex > 0) energyIndex--;

                lerpActuator = energyBlocks[energyIndex].GetComponent<ShaderFillDataManger>().fill;
                removeEnergy = false;
            }
        }

        // When Adding Energy
        if (plusEnergy)
        {
            removeEnergy = false;
            lerpActuator += Time.deltaTime * fadeRate;
            if (lerpActuator > 1f)
            {
                if (energyIndex < energyBlocks.Length - 1) energyIndex++;

                lerpActuator = energyBlocks[energyIndex].GetComponent<ShaderFillDataManger>().fill;
                
                if(energyIndex >= 4 && lerpActuator >= .5f )
                    Application.Quit();

                plusEnergy = false;
            }
        }

    }

    
}
