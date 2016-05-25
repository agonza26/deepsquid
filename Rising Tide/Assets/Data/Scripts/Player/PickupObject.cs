using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
press 'e' to grab an object, press 'e' again to release it
    if object's size is greater than player's, player will anchor to it
    else object will anchor to player
press 'q' to throw a held object (you can't throw objects bigger than you)

attach Pickupable script to any object that player should be able to pick up
attach PickupObject script to player
put the player model object on layer "Ignore Raycast" or it will get in the way
*/




public class PickupObject : MonoBehaviour {
	private string[] fishNames = new string[]{ "dankFish", "barracuda","snapper", "angler","dolphin","flounder" ,"manta", "tuna", "swordfish","sting ray", "manta ray", "whale"};


	private string targetFish = "none";
	private int targetCounter = 0;
	public float healthGain = 20f;
    public float objectSize;
    public bool parented = false;
    public bool canThrow;
    public float playerSize = 2.0f;
	public float distance = 1.5f; //offset between carried object and player
	public float smooth = 20f; //smooth carrying movement
    public float throwForce = 700f;
	public bool carrying = false; //must be public for improved movement;
	public AudioSource grabSound;
	public float holdDamage = 1f;

	private bool isEgg;
	private bool grabbableInRange = false;
	private Collider InRangeItemSaver;
	public GameObject carriedObject;
	private GameObject player;
	private GameObject bork;
	private bool doingDamageBool = false;
	public float waitTime = 0.5f;









	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		bork = GameObject.FindGameObjectWithTag ("borkVisualCollider");
	}



    void Update(){
		//if we aren't dead or in the egg
		isEgg = bork.GetComponent<TutorialObject> ().isEgg;
		if(!GetComponent<Player_stats>().isDead && !isEgg){
			


			//if we arent carrying anything
			if (!carrying){
				if(Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<Abilities>().currStamina >= 35) {
					pickup ();
				} 
			} else {
				if ((GetComponent<Abilities> ().currStamina <= 0f) || Input.GetKeyUp(KeyCode.Mouse0)) {
					dropObject ();
				} else if (Input.GetKeyDown(KeyCode.Mouse1)){ 
					throwObject ();
					
				}
			}
				
			//carrying could change from pickup, drop, or throw object
			if (carrying){
				carry(carriedObject);
			}
		}
    }








	//done changing
	private void pickup(){
		if (grabbableInRange && !isEgg){
			Pickupable p = InRangeItemSaver.GetComponent<Pickupable>(); 
			if (p != null){
				GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().hasGrabbed = true;
				grabSound.Play();
				carrying = p.grabbed(playerSize); //will do appropriate grab actions within own object, including auto drop if ability
				carriedObject = p.gameObject; //set our carried object to
				objectSize = p.size;
				grabbableInRange = false;
				parented = (playerSize < objectSize) && carrying;
			}
		}
	}
		




   private void carry(GameObject o){
        canThrow = true;
		Vector3 UnderPlayerPosition = player.transform.position+player.transform.forward*-3.5f;
		carriedObject.GetComponent<Pickupable> ().holding (UnderPlayerPosition, player.transform.rotation);


		if(carriedObject.tag == "Enemy"){
			if( !doingDamageBool )
				StartCoroutine (doingDamage());
			if(carriedObject.GetComponent<EnemyHealth>().enemyHealthCurr <= 0){
				restoreStats ();
				clearHolding ();
			}
		}
    }




    void dropObject(){
		carriedObject.GetComponent<Pickupable>().letGo (false, Vector3.zero, throwForce);
		clearHolding ();


    }




	private void clearHolding(){
		
		carriedObject.layer = 0; //return carried object to default layer
		carrying = false;
		carriedObject = null;
	}

	private void restoreStats(){
		GetComponent<Player_stats> ().playerRestoreHealth(carriedObject.GetComponent<EnemyHealth>().PlayerHealthRestoreValue); 
		Abilities a = GetComponent<Abilities> ();
		a.currStamina = Mathf.Min(a.maxStamina,a.currStamina + carriedObject.GetComponent<EnemyHealth>().PlayerHealthRestoreValue*15f);
	}






    void throwObject() {

		if (canThrow) {
			//carrying = false;

			carriedObject.GetComponent<Pickupable> ().letGo (true, transform.forward ,throwForce);
			clearHolding();
		} else {
			dropObject ();
		}
    }











	void OnTriggerStay(Collider c){
		if(c.GetComponent<Pickupable>() != null && c.tag != "MainCamera"){
			InRangeItemSaver = c;
			grabbableInRange = true;
			if(!carrying){
				if (c.GetComponent<NPCHighlighting> () != null) {
					c.GetComponent<NPCHighlighting> ().changeMatToHL ();
				}
			} else{
				if (c.GetComponent<NPCHighlighting> () != null) {
					c.GetComponent<NPCHighlighting> ().changeMatToNml ();
				}
			}
		}
	}


	void OnTriggerExit(Collider c){
		grabbableInRange = false;
		if (c.GetComponent<NPCHighlighting> () != null) {
			c.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}

	}






	public void targetUpdate (string key){
		targetFish = key;
		targetCounter = 0;
	}

	public void targetReset(){
		targetFish = "none";
		targetCounter = 0;
	}


	public int getTargetProgress(){
		return targetCounter;
	}


	public string getTarget(){
		return targetFish;
	}


	public void incrementTarget(){
		targetCounter++;

	}




	IEnumerator doingDamage(){
		doingDamageBool = true;
		carriedObject.GetComponent<EnemyHealth>().enemyTakeDmg(holdDamage);
		yield return new WaitForSeconds(waitTime);
		doingDamageBool = false;
	}





















	
}
