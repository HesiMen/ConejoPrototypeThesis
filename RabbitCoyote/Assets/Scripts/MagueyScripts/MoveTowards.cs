using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine.AI;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public float emergeHeight = 1f;
    public float emergeTime = 1f;

    public float moveToTargetSpeed = 3f;
    public float lookAtSpeed = .6f;
    public int vibrato = 40;

    public Vector2 shakeAmmount;

    public bool chase;
    [SerializeField] Transform test;
    private void Start()
    {
        EmergeAndLookTarget(test);
    }

    private void Update()
    {
        Vector3 targetPos = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

        transform.DOLookAt(targetPos, lookAtSpeed);
        if(chase)
        agent.SetDestination(test.position);
        
    }
    private void EmergeAndLookTarget(Transform target)
    {

        Vector3 directionShake = new Vector3(shakeAmmount.x, 0, shakeAmmount.y);
        Vector3 newTarget = new Vector3(target.position.x, this.transform.position.y + emergeHeight, target.position.z);

        Debug.Log(newTarget);
        Debug.Log(transform.position);
        Sequence movingSequence = DOTween.Sequence();

        movingSequence.Append(transform.DOShakePosition(emergeTime, directionShake, vibrato, 20, false, false))
            .Insert(0, transform.DOMoveY(this.transform.position.y + emergeHeight, emergeTime, false));
            
           
            

    }



}
