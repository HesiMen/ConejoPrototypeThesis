using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

using MalbersAnimations.Events;
using MalbersAnimations.Utilities;
using MalbersAnimations;

public class AnimalFollowController : MonoBehaviour {

	public AnimalType animal;
	public float CollisionRadius;
	public GameObject[] WayPoints;

	//[HideInInspector]
	public AnimalAIControl aiController;

	protected bool following;
	public bool traveling;
	protected int wayPointCount = 0;
	protected GameObject currentWaypoint;

	// Use this for initialization
	void Start () {
		aiController = GetComponent<AnimalAIControl>();
	}

	// Update is called once per frame
	void Update () {
		UpdateAnimal ();
	}

	protected void UpdateAnimal()
	{
		if (!traveling)
			CheckForPlayer ();
		else
		{
			if (currentWaypoint != null)
			{
				if (Vector3.Distance (transform.position, currentWaypoint.transform.position) < aiController.stoppingDistance + 2f)
				{
					Debug.Log ("Reached " + currentWaypoint.name);
					traveling = false;
					currentWaypoint = null;
				}
			}
		}
	}

	protected void FinishTask()
	{
	}

	protected void CheckForPlayer()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, CollisionRadius);

		if (hitColliders.Length != 0)
		{
			
		}
		else
		{
			Debug.Log("No collisions!");
		}

		//following = false;
		//aiController.SetTarget(null);

	}

	public string getWaypoint()
	{
		return WayPoints[(wayPointCount == 0 ? WayPoints.Length-1 : wayPointCount -1)].GetComponent<Waypoint>().AnimationTag;
	}

}