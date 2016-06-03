using UnityEngine;
using System.Collections;




public class BobbitEyes : MonoBehaviour
{

	public bool debugStatements = true;
	public float fieldOfViewAngle = 110f;           // Number of degrees, centred on forward, for the enemy see.
	public bool playerInSight;                      // Whether or not the player is currently sighted.
	public Vector3 personalLastSighting;            // Last place this enemy spotted the player.

	public SphereCollider col;                     // Reference to the sphere collider trigger component.
	private LastPlayerSighting lastPlayerSighting;  // Reference to last global sighting of the player.
	private GameObject player;                      // Reference to the player.
	private Vector3 previousSighting;               // Where the player was sighted last frame.
	private Transform dirtPos;
	//private float timer = 0f;
	public float timerLimit = 5f;


	void Awake ()
	{

		lastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
		player = GameObject.FindGameObjectWithTag("Player");
		dirtPos = transform.GetChild (0);
		personalLastSighting = lastPlayerSighting.resetPosition;
		previousSighting = lastPlayerSighting.resetPosition;
	}


	void Update ()
	{

		// If the last global sighting of the player has changed...
		if(lastPlayerSighting.position != previousSighting)
			// ... then update the personal sighting to be the same as the global sighting.
			personalLastSighting = lastPlayerSighting.position;

		// Set the previous sighting to the be the sighting from this frame.
		previousSighting = lastPlayerSighting.position;

		if (playerInSight) 
		{

			//BasicEnemy brain = GetComponent<BasicEnemy>();
			//if (brain.state != "follow") 
			//{
			//	brain.state = "follow";

			//}
		}
	}








	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player)
		{


			// By default the player is not in sight.
			playerInSight = false;

			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - dirtPos.position;
			float angle = Vector3.Angle(direction, dirtPos.forward);


			// If the angle between forward and where the player is, is less than half the angle of view...
			if(angle < fieldOfViewAngle * 0.5f)
			{

				RaycastHit hit;	
				Debug.DrawRay(dirtPos.position, direction);

				// ... and if a raycast towards the player hits something...
				if(Physics.Raycast(dirtPos.position, direction, out hit, col.radius))
				{
					Debug.DrawRay(dirtPos.position, direction);


					if(hit.collider.gameObject.name == "squidHead")
					{
						BobbitBrain brain = GetComponent<BobbitBrain>();
						brain.message = "seePlayer";
						playerInSight = true;
						// Set the last global sighting is the players current position.
						lastPlayerSighting.position = player.transform.position;
					}

				}

			}	
		}


	}





	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if (other.gameObject == player) {


			playerInSight = false;
			BasicEnemy brain = GetComponent<BasicEnemy>();
			brain.message = "lostPlayer";

		}
	}


}