﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MyTasksEvents : UnityEvent { }
public class BeatEventSystem : MonoBehaviour
{

    public BeatEvent[] beatEvents;

    public MyTasksEvents HoldingSeeds;
    public MyTasksEvents PlantingSeeds;
    public MyTasksEvents PlantingReward;
    public MyTasksEvents FiveSticks;
    public MyTasksEvents FireStickAndStickReady;
    public MyTasksEvents StickToMakeFire;
    public MyTasksEvents FireReward;



    private void OnEnable()
    {
        foreach (BeatEvent beat in beatEvents)
        {
            beat.completeEvent += TaskCompleted;
        }
    }

    private void OnDisable()
    {
        foreach (BeatEvent beat in beatEvents)
        {
            beat.completeEvent -= TaskCompleted;
        }
    }


    private void TaskCompleted(BeatEvent.Beats whichBeat, BeatEvent.WhichTask whichTask)
    {
        Debug.Log(whichBeat);
        Debug.Log(whichTask);
        switch (whichBeat)
        {
            case BeatEvent.Beats.Beat1:

                switch (whichTask)
                {
                    case BeatEvent.WhichTask.HoldingSeeds:
                        HoldingSeeds.Invoke();
                        Debug.Log("HoldingSeedsDone");
                        break;

                    case BeatEvent.WhichTask.PlantingSeeds:
                        PlantingSeeds.Invoke();
                        break;

                    case BeatEvent.WhichTask.PlantingReward:
                        PlantingReward.Invoke();
                        break;
                }
                break;

            case BeatEvent.Beats.Beat2:

                switch (whichTask)
                {
                    case BeatEvent.WhichTask.FiveSticks:
                        FiveSticks.Invoke();
                        break;

                    case BeatEvent.WhichTask.FireStickAndStickReady:
                        FireStickAndStickReady.Invoke();
                        break;

                    case BeatEvent.WhichTask.FireReward:
                        FireReward.Invoke();
                        break;
                }

                break;

            case BeatEvent.Beats.Beat3:

                break;

            case BeatEvent.Beats.Beat4:

                break;

            case BeatEvent.Beats.Beat5:

                break;


            case BeatEvent.Beats.Beat6:

                break;
        }
    }
}