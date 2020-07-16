using MalbersAnimations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIGeneraMovement : MonoBehaviour
{
    #region References
    public NavMeshAgent agent;
    Animal animal;
    public bool AutoSpeed = true;
    public float seconds = 4f;
    #endregion
    public float stoppingDistance = 0.6f;
    public Vector3 target;
    public float wanderRadious;

    public bool autoSpeed = true;
    public float ToTrot = 6f;
    public float ToRun = 8f;

    [SerializeField] private bool _isBunny;


    public bool debug = false;                //Debuging 



    public bool isMoving = false;


    public NavMeshAgent Agent
    {
        get
        {
            if (agent == null)
            {
                agent = GetComponentInChildren<NavMeshAgent>();
            }
            return agent;
        }
    }

    void Start()
    {
        // if (autoSpeed) AutomaticSpeed();

        animal = GetComponent<Animal>();
        if (!_isBunny)
        {
            target = RandomNavmeshLocation(wanderRadious);

            agent.stoppingDistance = stoppingDistance;
            //StartCoroutine(StartChasing());
            AssignMovementTask(target);



        }
    }

    private void Update()
    {



        if (!_isBunny)
        {

            if (HasReachedPos())
            {
                animal.Action = true;
                StartCoroutine(StartChasing());
            }
        }
        else
        {

        }


    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }


    public void AssignMovementTask(Vector3 goalPos)
    {

        agent.SetDestination(goalPos);
        animal.Move(goalPos);
    }

    public bool HasReachedPos()
    {
        if (!agent.isOnNavMesh)
            return false;
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!Agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    //Finished moving  do another target;
                    return true;

                }
            }
        }
        return false;
    }

    IEnumerator StartChasing()
    {
        Agent.isStopped = true;
        yield return new WaitForSeconds(seconds);
        target = RandomNavmeshLocation(wanderRadious);
        Agent.isStopped = false;
        AssignMovementTask(target);
        //  animal.Move(target);
    }

    public virtual void AutomaticSpeed()
    {

        if (Agent.remainingDistance < ToTrot)         //Set to Walk
        {
            animal.Speed1 = true;
        }
        else if (Agent.remainingDistance < ToRun)     //Set to Trot
        {
            animal.Speed2 = true;
        }
        else if (Agent.remainingDistance > ToRun)     //Set to Run
        {
            animal.Speed3 = true;
        }
    }
    void OnDrawGizmos()
    {
        if (debug)
        {

            Debug.DrawLine(transform.position, target, Color.green);

        }
    }


}
