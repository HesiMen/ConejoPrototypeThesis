﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmergeScript : MonoBehaviour
{
    public bool _emergeOnDistance;
    public float emergeTime = .5f;
    public Vector2 shakeAmmount;
    public int vibrato = 40;
    public int randomness = 20;
    [SerializeField] Transform rock;
    [SerializeField] Transform player;
    [SerializeField] ParticleSystem dirt;
    public float maxDistance = 4;
    public float maxHeight = 1.5f;

    Vector3 directionShake;

    bool min = false;

    bool mid = false;

    bool max = false;
    private void Start()
    {
        directionShake = new Vector3(shakeAmmount.x, 0, shakeAmmount.y);

    }
    private void Update()
    {

        if (_emergeOnDistance)
        {
            float distanceCheck = Vector3.Distance(rock.position, player.position);

            if (distanceCheck < maxDistance)
            {

                if (Mathf.Round(distanceCheck) == maxDistance)
                {
                    if (!min)
                    {
                        Emerge(maxHeight / 4f);
                        Debug.Log("MaxHeigh");
                        min = true;
                        dirt.Play();
                    }
                }

                if (Mathf.Round(distanceCheck) == (maxDistance / 2f))
                {
                    if (!mid)
                    {
                        Emerge(maxHeight / 2f);
                        Debug.Log("halfway");
                        mid = true;
                        dirt.Play();
                    }
                }

                if (Mathf.Round(distanceCheck) == (maxDistance / 4f))
                {
                    if (!max)
                    {
                        Emerge(maxHeight);
                        Debug.Log("max");
                        max = true;
                        dirt.Play();
                    }
                }
            }


        }
    }

    private void Emerge(float ammountY)
    {
        Sequence emergeSequence = DOTween.Sequence();

        emergeSequence.Append(transform.DOShakePosition(emergeTime, directionShake, vibrato, randomness, false, false))
            .Insert(0, transform.DOMoveY(ammountY, emergeTime, false));
    }
}