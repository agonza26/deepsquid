using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EcoPoints : MonoBehaviour {
	//until we have more fish im not using an array or list for game objects

	public int yellowSnappers = 0;
	public int barracuda = 0;
	public bool autoSpawn = false;
 


	public BoxCollider spawnBoxCage;
	public SphereCollider spawnSphereTrigger;




	public GameObject snapperPrefab;
	public GameObject barracudaPrefab;


	public List<GameObject> EnemContainerS = new List<GameObject>();
	public List<GameObject> EnemContainerD = new List<GameObject>();
	public List<GameObject> DeadEnemContainer = new List<GameObject>();



	public Dictionary<string,GameObject> Ecopoints = new Dictionary<string,GameObject>();
	public Dictionary<string,GameObject> Enemies = new Dictionary<string,GameObject>();
	public Dictionary<string,GameObject> Dump = new Dictionary<string,GameObject>();
	//private static int fishCount = -1;
	//private string name = "none";



	public bool debug = true;
	private bool gone = false;
	private float recycleTimer = 0;
	public float recycleTimeLimit = 5;

	public void Die(GameObject it){
		
		EnemContainerD.Remove (it);
		DeadEnemContainer.Add (it);
		it.SetActive (false);
	}


	public void Resurrect(GameObject it){
		print ("giving life");
		it.SetActive (true);
		EnemContainerS.Add (it);
		DeadEnemContainer.Remove (it);

		//Reset everything 

	//	it.GetComponent<BasicEnemy> ().Reset ();
	//	it.GetComponent<EnemyHealth> ().Reset ();
	//	it.GetComponent<EnemySight> ().Reset ();
	}

	// Use this for initialization
	void Start () {
		name = gameObject.name;

		/*
		for (int i = 0; i < yellowSnappers; ++i) {
			float x = transform.position.x;
			float y = transform.position.x;
			float z = transform.position.x;
			Vector3 position = new Vector3 (x, y, z);
			Quaternion itRot = Random.rotation; 
			CapsuleCollider capN = snapperPrefab.GetComponent<CapsuleCollider>();

			do {
				position.x = Random.Range (transform.position.x - spawnBoxCage.size.x, transform.position.x + spawnBoxCage.size.x);
				position.y = Random.Range (transform.position.y - spawnBoxCage.size.y, transform.position.y + spawnBoxCage.size.y);
				position.z = Random.Range (transform.position.z - spawnBoxCage.size.z, transform.position.z + spawnBoxCage.size.z);

//				fuck this shit i want burritos and nachos ;



			} while(!Physics.CheckCapsule (position - (itRot * Vector3.forward) * (capN.height / 2 - capN.radius), position + (itRot * Vector3.forward) * (capN.height / 2 - capN.radius), capN.radius));
				

			GameObject it = (GameObject)Instantiate(snapperPrefab, position, itRot);
			it.GetComponent<BasicEnemy>().ecosystem = name;

			//setup the component scripts
		}

		*/
	}




	void Update(){
		if(gone && EnemContainerS.Count > 0){
			foreach (GameObject value in EnemContainerS){
				EnemContainerD.Add (value);
				value.SetActive (false);
			}
			EnemContainerS.Clear();
		}


		if(!gone && EnemContainerD.Count > 0){
			foreach (GameObject value in EnemContainerD){
				EnemContainerS.Add (value);
				value.SetActive (true);
			}
			EnemContainerD.Clear();
		}



		if (DeadEnemContainer.Count > 0) {
			recycleTimer += Time.deltaTime;
			if(recycleTimer >= recycleTimeLimit){
				Resurrect (DeadEnemContainer [0]);
				recycleTimer = 0;
			}
		}


		if (Input.GetKeyDown ("k") && !gone && debug &&EnemContainerS.Count>0) {
			Die(EnemContainerS[0]);


		}



	}

	public void Add(GameObject it){
		EnemContainerS.Add (it);
	}


	public void despawn(){
		gone = true;
	}



	public void respawn(){
		gone = false;
	}












	void OnTriggerEnter(Collider enter){
		
		//if we haven't collected any EcoPoints
		if (!Ecopoints.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "EcoPoint") {
			Ecopoints.Add (enter.gameObject.name, enter.gameObject);

			//if we haven't collected any Enemies
		} else if (!Enemies.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "Enemy") {
			Enemies.Add (enter.gameObject.name, enter.gameObject);

			//dump to find anything else ie player
		} else if(!Dump.ContainsKey (enter.gameObject.name)){
			Dump.Add (enter.gameObject.name, enter.gameObject);
		}
	}



	void OnTriggerExit(Collider enter){


		if (Ecopoints.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "EcoPoint") {
			Ecopoints.Remove (enter.gameObject.name);

		} else if (Enemies.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "Enemy") {
			Enemies.Remove (enter.gameObject.name);

		} else if(Dump.ContainsKey (enter.gameObject.name)){
			Dump.Remove (enter.gameObject.name);
		}
	}
}
