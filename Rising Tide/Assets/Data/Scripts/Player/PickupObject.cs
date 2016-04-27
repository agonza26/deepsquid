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
 
	public float healthGain = 20f;
    public float objectSize;
    public bool parented = false;
    public bool canThrow;
	public ParticleSystem blood;
    public float playerSize = 2.0f;
	public float distance = 1.5f; //offset between carried object and player
	public float smooth = 20f; //smooth carrying movement
    public float throwForce = 700f;
	public bool carrying = false; //must be public for improved movement;
	public AudioSource grabSound;


	private bool isEgg;
	private bool grabbableInRange = false;
	private Collider InRangeItemSaver;
	public GameObject carriedObject;
	private GameObject player;
	private GameObject bork;

   
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		bork = GameObject.FindGameObjectWithTag ("borkVisualCollider");
	}


    void Update(){
		//if we aren't dead or in the egg
		isEgg = bork.GetComponent<TutorialObject> ().isEgg;
		if(!GetComponent<Player_stats>().isDead && !isEgg){
			
			if((GetComponent<Abilities>().currStamina <= 0f)&&(carrying)){
				dropObject();
			}

			//if we arent carrying anything
			if (!carrying){
				if(Input.GetKeyDown(KeyCode.Mouse0)) {
					print ("we picked up");
					pickup ();
				} 
			} else {
				if(Input.GetKeyUp(KeyCode.Mouse0))
				{
					dropObject();
				}
				
				if (Input.GetKeyDown(KeyCode.Mouse1)){
					if (canThrow) {
						throwObject ();
					} else {
						dropObject ();
					}
				}
			}

			if (carrying){
				carry(carriedObject);
				if(carriedObject.tag == "Enemy")
				{
					carriedObject.GetComponent<EnemyHealth>().enemyTakeDmg(GetComponent<Player_stats>().giveDmg() * 8f * Time.deltaTime);
					//GetComponent<Abilities>().depleteStam(10f);
					if(carriedObject.GetComponent<EnemyHealth>().enemyHealthCurr <= 0)
					{
						GetComponent<Player_stats> ().playerRestoreHealth(carriedObject.GetComponent<EnemyHealth>().PlayerHealthRestoreValue); 
						Abilities a = GetComponent<Abilities> ();
						a.currStamina += carriedObject.GetComponent<EnemyHealth>().PlayerHealthRestoreValue*15f;
						if (a.currStamina > a.maxStamina)
							a.currStamina = a.maxStamina;
						carrying = false;
						blood.transform.position = player.transform.position;
						blood.transform.forward = player.transform.forward;
						Vector3 littlebitforward = blood.transform.position;
						littlebitforward.z += 2f;
						blood.transform.position = littlebitforward;
						blood.Emit(25);
						dropObject();
					}
				}
			}
		}
    }








	//done changing
	void pickup()
	{

			if (grabbableInRange && !isEgg)
			{
				Pickupable p = InRangeItemSaver.GetComponent<Pickupable>(); 
				
				if (p != null)
				{
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





















    void carry(GameObject o)
    {


        
	
		if (!parented) //object is smaller than player
        {
            canThrow = true;
			Vector3 UnderPlayerPosition = player.transform.position+player.transform.forward*-3.5f;
			carriedObject.GetComponent<Pickupable> ().holding (UnderPlayerPosition, player.transform.rotation);
        }
        else //object is larger than player
        {



            canThrow = false; // get rid of this for super squid strength
			Vector3 objSize = (o.GetComponent<Collider>().bounds.size)/ 2f;
			player.GetComponent<Rigidbody>().isKinematic = true; //without this it won't move with the parent
			parented = true;
			player.transform.position = Vector3.Lerp(player.transform.position, o.transform.position - objSize , Time.deltaTime );


        }
    }




    void dropObject()
    {


        carrying = false;
        carriedObject.layer = 0; //return carried object to default layer
        if (parented){
            player.transform.parent = null;
            parented = false;
            player.GetComponent<Rigidbody>().isKinematic = false;            
            Debug.Log("releasing big object");
        }
        carriedObject.GetComponent<Rigidbody>().useGravity = true; //disabling for now
		//carriedObject.GetComponent<Rigidbody>().AddForce(GetComponent<improved_movement>().getMovement());
		carriedObject.GetComponent<Rigidbody> ().drag = 1f;
        carriedObject = null;
    }






    void throwObject()
    {

		if (canThrow) {
			//carrying = false;
			carrying = false;
			carriedObject.GetComponent<Rigidbody> ().AddForce (transform.forward * -throwForce);
			carriedObject.GetComponent<Rigidbody> ().useGravity = true;
			carriedObject.GetComponent<Pickupable> ().changeThrown ();
			carriedObject.layer = 0; //return carried object to default layer
			carriedObject = null;


		} else {
			dropObject ();
		}
    }








	//leave alone, is working
	void OnTriggerEnter(Collider c)
	{
		if(c.GetComponent<Pickupable>() != null && c.tag != "MainCamera")
		{
			InRangeItemSaver = c;
			grabbableInRange = true;
			if(c.GetComponent<NPCHighlighting> () != null){
				c.GetComponent<NPCHighlighting> ().changeMatToHL (); //getting null
			}
		}
	}

	void OnTriggerStay(Collider c)
	{
		if(c.GetComponent<Pickupable>() != null && c.tag != "MainCamera")
		{
		InRangeItemSaver = c;
		grabbableInRange = true;
		if(!carrying)
		{
				if (c.GetComponent<NPCHighlighting> () != null) {
					c.GetComponent<NPCHighlighting> ().changeMatToHL ();
				}
		} 
		else
		{
				if (c.GetComponent<NPCHighlighting> () != null) {
					c.GetComponent<NPCHighlighting> ().changeMatToNml ();
				}
		}
		
		}
	}
	
	void OnTriggerExit(Collider c)
	{
		grabbableInRange = false;
		if(c)
		{
			if (c.GetComponent<NPCHighlighting> () != null) {
				c.GetComponent<NPCHighlighting> ().changeMatToNml ();
			}
		}
	}

	
}
