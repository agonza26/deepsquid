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
	
	public ParticleSystem blood;

    public GameObject player;
    public float playerSize = 2.0f;
    public float distance = 1.5f; //offset between carried object and player
    public float smooth = 20f; //smooth carrying movement
    public float throwForce = 700f;
    private Quaternion playerZRot;
    //public float rayDistance; //how far away an object can be picked up from

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
		/*blood = gameObject.GetComponentInChildren<ParticleSystem>();
		blood.enableEmission = true;
		*/
        if (carrying)
        {
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
            //put the object below player, move sorta smoothly with Lerp
            float d = (o.GetComponent<Collider>().bounds.size.z) * 0.2f;
            playerZRot = player.transform.rotation;
			Vector3 UnderPlayerPosition = player.transform.position+player.transform.forward*-4;
            o.transform.localPosition = Vector3.Lerp(o.transform.position, UnderPlayerPosition, Time.deltaTime * smooth);
            o.transform.rotation = playerZRot; //stop picked up object from rotating independently
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
            //shoot ray from center of screen
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y)); //shoot ray from middle of screen 
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit))
            {
				float distFromObj = Vector3.Distance(hit.transform.position, player.transform.position);
                if(distFromObj < 60f)
				{
					//if it hits something valid, pick it up
					Pickupable p = hit.collider.GetComponent<Pickupable>(); 
					if (p != null)
					{
						Debug.Log("that can be picked up");
						carrying = true;
						carriedObject = p.gameObject;
						//p.gameObject.GetComponent<Rigidbody>().isKinematic = true; //not used //so that we can move the object around w/o it being affected by gravity, etc
						//gameObject.GetComponent<Rigidbody>().useGravity = false; //moved this line to carry function
						objectSize = p.size;
					}
				}
				Debug.Log(hit.transform.gameObject);
				Debug.Log("You are " + distFromObj + " from " + hit);

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
	
}
