using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioTest : MonoBehaviour
{
    [Tooltip("The scriptable allows easy access of sounds through code. The full library will be usable through this single scriptable object.")]
    [SerializeField] private FMODScriptableObject sounds;

    [Tooltip("If a sound path is selected through soundClip the script will use the event reference over the scriptable object.")]
    [FMODUnity.EventRef] [SerializeField] private string soundClip;

    [Tooltip("True = Spatial sound effect | False = 2D sound")]
    [SerializeField] private bool sound3D;

    [Tooltip("Parameter name is defined in FMOD this string variable allows you to type in the specific parameter that you would like to adjust. To avoid having to open up FMOD to access parameter names, they will be available through the scriptable object 'Maguey-Sound-Library'. To view parameters hover your mouse cursor over the sound's name in the inspector after having selected the scriptable object and it will give you a breakdown of the parameter names and what the values do. For more information contact Jonathan :)")]
    [SerializeField] private string parameterName;
    [Tooltip("Adjust parameter value between 0 and 1 therefore all parameters should stay in this range for scalability.")]
    [SerializeField] [Range(0,1)] private float parameterValue;

    FMOD.Studio.EventInstance soundState; 
    FMOD.Studio.PARAMETER_ID myParameterID;

    [Tooltip("Specify a keyboard key to debug sounds.")]
    public KeyCode pressForSound;

    void Start() 
    {
        // Set Instance
        if (soundClip == null)
            soundState = FMODUnity.RuntimeManager.CreateInstance(sounds.stone); //call sound via scriptable object

        if (soundClip != null)
            soundState = FMODUnity.RuntimeManager.CreateInstance(soundClip);    //call sound  via event ref


        // Parameter initialization
        FMOD.Studio.EventDescription myEventDescription;
        soundState.getDescription(out myEventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION myParameterDescription;
        myEventDescription.getParameterDescriptionByName(parameterName, out myParameterDescription);
        myParameterID = myParameterDescription.id;
    }

    // Update is called once per frame
    void Update()
    {
        PlaySoundOneShot2D();   //play 2d sound
        Play3DSound();          //play 3D sound

        // Parameter Control in realtime
        soundState.setParameterByID(myParameterID, parameterValue);
    }

    void PlaySoundOneShot2D()
    {   
        if (Input.GetKeyDown(pressForSound) && !sound3D)
        {
            // Play one shot plays sound
            FMODUnity.RuntimeManager.PlayOneShot(sounds.stone);
        }
    }

    void Play3DSound()
    {
        if (sound3D)
        {
            // Used to attach audio to gameObject
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundState, this.gameObject.GetComponent<Transform>(), this.gameObject.GetComponent<Rigidbody>());

            if (Input.GetKeyDown(pressForSound))
            {
                soundState.start();
            }
        }
    }
}
