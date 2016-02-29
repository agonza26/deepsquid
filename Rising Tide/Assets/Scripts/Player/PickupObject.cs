using UnityEngine;
using System.Collections;

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

    GameObject mainCamera;
    public bool carrying = false;
    GameObject carriedObject;
    float objectSize;
    bool parented = false;
    bool canThrow;
	bool grabbableInRange = false;
	Collider InRangeItemSaver;
	
	public ParticleSystem blood;

    public GameObject player;
	public GameObject speedObject;
	public GameObject inkObject;
    public float playerSize = 2.0f;
    public float distance = 1.5f; //offset between carried object and player
    public float smooth = 20f; //smooth carrying movement
    public float throwForce = 700f;
    private Quaternion playerZRot;
    //public float rayDistance; //how far away an object can be picked up from

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
			if(carriedObject.tag == "Enemy")
			{
				carriedObject.GetComponent<EnemyHealth>().enemyTakeDmg(GetComponent<Player_stats>().giveDmg() * 8f * Time.deltaTime);
				
				if(carriedObject.GetComponent<EnemyHealth>().enemyHealthCurr <= 0)
				{
					Debug.Log("playing blood particle system...");
					carrying = false;
					transform.GetComponent<Player_stats>().playerDamage(-carriedObject.GetComponent<EnemyHealth>().PlayerHealthRestoreValue);
					blood.Play();
					dropObject();
					grabbableInRange = false;
				}
			}
			if(carrying)
				carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }

    }

    void carry(GameObject o)
    {
        o.layer = 2; //put grabbed object on IgnoreRaycast layer (to avoid camera freakouts

        if (playerSize > objectSize) //object is smaller than player
        {
            canThrow = true;
            o.GetComponent<Rigidbody>().useGravity = false;
			Debug.Log(o.transform.position);
            //put the object below player, move sorta smoothly with Lerp
            float d = (o.GetComponent<Collider>().bounds.size.z);
			float halfPlayer = player.GetComponent<Renderer>().bounds.size.z * 0.5f;
			float totalOffset = d + halfPlayer + 1f;
			Vector3 UnderPlayerPosition = player.transform.position + player.transform.forward;//*-4;
			UnderPlayerPosition -= player.transform.forward * totalOffset;
			//UnderPlayerPosition.z += d + halfPlayer;
            //o.transform.localPosition = Vector3.Lerp(o.transform.position, UnderPlayerPosition, Time.deltaTime * smooth);
			o.transform.position = Vector3.Lerp(o.transform.position, UnderPlayerPosition, Time.deltaTime * smooth);
            //o.transform.rotation = playerZRot; //stop picked up object from rotating independently
        }

        else //object is larger than player
        {
            canThrow = false; // get rid of this for super squid strength
            if (!parented)
            {
                //position player alongside grabbed object
                Vector3 objSize = (o.GetComponent<Collider>().bounds.size)/ 2f;
                player.transform.position = Vector3.Lerp(player.transform.position, o.transform.position - objSize, Time.deltaTime * smooth);

                //make player child of grabbed object for movement and rotation
                player.transform.parent = o.transform.GetChild(0); //emptyObject, child of grabbed one, to avoid distortion of player model
                player.GetComponent<Rigidbody>().isKinematic = true; //without this it won't move with the parent
                parented = true;
                //o.layer = 2; //move grabbed ogject to IgnoreRaycast layer (to avoid camera freakouts)

            }
            Debug.Log("anchor to big object");
        }
    }

    void pickup()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (grabbableInRange)
            {

                //Debug.Log(hit.transform.gameObject);
                //if it hits something valid, pick it up
                Pickupable p = InRangeItemSaver.GetComponent<Pickupable>(); 
                if (p != null)
                {
                   // Debug.Log("that can be picked up");
					//Debug.Log("the object carried is" + p.gameObject + "and its tag is: " + p.gameObject.tag);
                    carrying = true;
                    carriedObject = p.gameObject;
					if (p.gameObject == speedObject) {
						speedObject.tag = "AbilitySpeed";
					}
					if (p.gameObject == inkObject) {
						inkObject.tag = "AbilityInk";
					}
                    //p.gameObject.GetComponent<Rigidbody>().isKinematic = true; //not used //so that we can move the object around w/o it being affected by gravity, etc
                    //gameObject.GetComponent<Rigidbody>().useGravity = false; //moved this line to carry function
                    objectSize = p.size;
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canThrow)
            {
                throwObject();
            }
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
        //carriedObject.GetComponent<Rigidbody>().useGravity = true; //disabling for now
        carriedObject = null;
    }

    void throwObject()
    {
        //carrying = false;
       
        //carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        dropObject();
        //carriedObject = null;
    }
	
	void OnTriggerEnter(Collider c)
	{
		if(c.GetComponent<Pickupable>() != null && c.tag != "MainCamera")
		{
			Debug.Log("A grabbable item " + c + " is in range");
			grabbableInRange = true;
		}
		
		InRangeItemSaver = c;
	}
	
	void OnTriggerExit(Collider c)
	{
		grabbableInRange = false;
		Debug.Log("Grabbable item " + c + " has left the grab range");
	}
	
}
