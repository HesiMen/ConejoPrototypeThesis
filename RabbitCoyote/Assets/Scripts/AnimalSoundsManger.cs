using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundsManger : MonoBehaviour
{
    [FMODUnity.EventRef]
    public List<string> bankPath;

    FMOD.Studio.EventInstance soundEvent1;
    FMOD.Studio.EventInstance soundEvent2;
    FMOD.Studio.EventInstance soundEvent3;

    public KeyCode[] pressForSound;

    [Range(1, 40)]
    public int timeTillNextSound;

    // Start is called before the first frame update
    void Start()
    {
        //Create Instances for sound events
        soundEvent1 = FMODUnity.RuntimeManager.CreateInstance(bankPath[0]);
        soundEvent2 = FMODUnity.RuntimeManager.CreateInstance(bankPath[1]);
        soundEvent3 = FMODUnity.RuntimeManager.CreateInstance(bankPath[2]);
    }

    // Update is called once per frame
    void Update()
    {
        // Attach to a game object
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEvent1, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEvent2, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEvent3, GetComponent<Transform>(), GetComponent<Rigidbody>());
        DebugPlaySound();

        //Breathing Sounds
        if ((Mathf.RoundToInt(Time.time) + 1) % timeTillNextSound == 0)
        {
            StartCoroutine(PlaySoundOverTime());
        }

    }

    void DebugPlaySound()
    {
        if (Input.GetKeyDown(pressForSound[0]))
        {
            //Barking
            soundEvent1.start();
            Debug.Log("Played 1");
        }
        if (Input.GetKeyDown(pressForSound[1]))
        {
            //breathing
            soundEvent2.start();
            Debug.Log("Played 2");
        }
        if (Input.GetKeyDown(pressForSound[2]))
        {
            //Whining
            soundEvent3.start();
            Debug.Log("Played 3");
        }
    }

    IEnumerator PlaySoundOverTime()
    {
        soundEvent2.start();
        yield return new WaitForSeconds(5f);
    }
}
