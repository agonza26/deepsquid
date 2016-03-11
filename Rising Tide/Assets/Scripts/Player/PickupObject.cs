﻿using UnityEngine;
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

public class PickupObject : MonoBehaviour


{
	
    
   
    public float objectSize;
    public bool parented = false;
    public bool canThrow;
	public ParticleSystem blood;
    public float playerSize = 2.0f;
    


	public float distance = 1.5f; //offset between carried object and player
	public float smooth = 20f; //smooth carrying movement
    public float throwForce = 700f;
	public bool carrying = false; //must be public for improved movement;





	private Quaternion playerZRot;


	private bool grabbableInRange = false;
	private Collider InRangeItemSaver;
	private GameObject carriedObject;
	private GameObject player;

   
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");


	}


    void Update()
	{
		/*blood = gameObject.GetComponentInChildren<ParticleSystem>();
		blood.enableEmission = true;
		*/


		if (!carrying) {
			if(Input.GetKey (KeyCode.Mouse0))
				pickup ();
		} else {
			if (Input.GetKeyDown(KeyCode.E))
				dropObject();
			else if (Input.GetKeyDown(KeyCode.Q))
			{
				if (canThrow)
				{
					throwObject();
				}
			}


		}



		if (carrying){
			
			if(carriedObject.tag == "Enemy")
			{
				carriedObject.GetComponent<EnemyHealth>().enemyTakeDmg(GetComponent<Player_stats>().giveDmg() * 8f * Time.deltaTime);
				
				if(carriedObject.GetComponent<EnemyHealth>().enemyHealthCurr <= 0)
				{
					Debug.Log("playing blood particle system...");
					carrying = false;
					blood.Play();
					dropObject();
				}
			}





			if(carrying)
				carry(carriedObject);
            







        }
    }








	//done changing
	void pickup()
	{

			if (grabbableInRange)
			{
				Pickupable p = InRangeItemSaver.GetComponent<Pickupable>(); 
				
				if (p != null)
				{
					
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
            playerZRot = player.transform.rotation;
			Vector3 UnderPlayerPosition = player.transform.position+player.transform.forward*-4;
			//lerp doesn't work how we want it to, but i'm leaving the code for me to use later - alex
           	//Vector3.Lerp(o.transform.position, UnderPlayerPosition, Time.deltaTime );
			carriedObject.GetComponent<Pickupable> ().holding (UnderPlayerPosition, playerZRot);
        }
        else //object is larger than player
        {



            canThrow = false; // get rid of this for super squid strength
			Vector3 objSize = (o.GetComponent<Collider>().bounds.size)/ 2f;
			player.GetComponent<Rigidbody>().isKinematic = true; //without this it won't move with the parent
			parented = true;
			player.transform.position = Vector3.Lerp(player.transform.position, o.transform.position - objSize, Time.deltaTime );


        }
    }






















    void dropObject()
    {


        carrying = false;
        carriedObject.layer = 0; //return carried object to default layer
        if (parented)
        {
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
		}


	}

	void OnTriggerExit(Collider c)
	{
		grabbableInRange = false;

	}

	
}
