﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

[Serializable]
public class EmergeEvent : UnityEvent { }
public class EmergeScript : MonoBehaviour
{
    


  

    [SerializeField]
    private int endLoop;


    public bool _emergeOnDistance;
    public bool _emergeOnEvent;
    public bool _emergeNow = false;
    public float emergeTime = .5f;
    public Vector2 shakeAmmount;
    public int vibrato = 40;
    public int randomness = 20;
    [SerializeField] Transform rock;
    [ConditionalHide("_emergeOnDistance", true)]
    [SerializeField] Transform player;
    [SerializeField] ParticleSystem dirt;
    [ConditionalHide("_emergeOnDistance", true)]
    public float maxDistance = 4;
    public float maxHeight = 1.5f;

    Vector3 directionShake;

    bool min = false;

    bool mid = false;

    bool max = false;


    public EmergeEvent StartEmerge;
    public EmergeEvent MidEmerge;
    public EmergeEvent EndEmerge;

    public EmergeEvent EmergeShotStart;
    public EmergeEvent EmergeShotEnd;


   
    private void Start()
    {

       
        directionShake = new Vector3(shakeAmmount.x, 0, shakeAmmount.y);

    }
    private void Update()
    {

       

        if (_emergeOnDistance && !_emergeOnEvent)
        {

            float distanceCheck = Vector3.Distance(rock.position, player.position);

            if (distanceCheck < maxDistance)
            {

                if (Mathf.Round(distanceCheck) == maxDistance)
                {
                    if (!min)
                    {
                        Emerge(maxHeight / 4f);
                        StartEmerge.Invoke();
                        min = true;
                        dirt.Play();

                    }
                }

                if (Mathf.Round(distanceCheck) == (maxDistance / 2f))
                {
                    if (!mid)
                    {
                        Emerge(maxHeight / 2f);
                        MidEmerge.Invoke();
                        mid = true;
                        dirt.Play();
                    }
                }

                if (Mathf.Round(distanceCheck) == (maxDistance / 4f))
                {
                    if (!max)
                    {
                        Emerge(maxHeight);

                        EndEmerge.Invoke();
                        max = true;
                        dirt.Play();
                    }
                }
            }



        }

        if (_emergeOnEvent && !_emergeOnDistance && _emergeNow)
        {

            Emerge(maxHeight);
            Debug.Log("max");
            max = true;
            dirt.Play();
            _emergeOnEvent = false;

        }


    }

    public void EmergeNowEventActive()
    {
        _emergeNow = true;
    }

    private void Emerge(float ammountY)
    {



        

        Sequence emergeSequence = DOTween.Sequence();

        emergeSequence.Append(transform.DOShakePosition(emergeTime, directionShake, vibrato, randomness, false, false))
            .Insert(0, transform.DOMoveY(ammountY, emergeTime, false)).OnStart(StartedEmerge).OnComplete(FinishedEmerge);


    }



    private void FinishedEmerge()
    {
        EmergeShotEnd.Invoke();
        //endLoop = 1;
        // stoneRise.setParameterByName("EndStoneLoop", endLoop);
    }

    private void StartedEmerge()
    {
        EmergeShotStart.Invoke();


        // endLoop = 0;
        // stoneRise.setParameterByName("EndStoneLoop", endLoop);


    }

   
}
