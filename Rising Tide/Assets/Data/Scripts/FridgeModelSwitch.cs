using UnityEngine;
using System.Collections;

public class FridgeModelSwitch : MonoBehaviour {

	public GameObject other;
	public bool isFirst = false;
	public GameObject milk;

	// Use this for initialization
	void Start () {
		milk = GameObject.Find("milkBox");
		other = GameObject.Find("BrokenFridge");
		if (!isFirst) {
			gameObject.SetActive (false);
		} else {
			other.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision o){
		if (o.gameObject.GetComponent<Pickupable> () && other) {
			if (o.gameObject.GetComponent<Pickupable> ().isThrown ())
					changeModels ();
			}
		
		
	}

    //allow breakage even if thrown while already in collider?
    void OnCollisionStay(Collision o)
    {
        if (o.gameObject.GetComponent<Pickupable>() && other)
        {
            if (o.gameObject.GetComponent<Pickupable>().isThrown())
            {
				o.gameObject.GetComponent<Pickupable> ().changeThrown ();
                changeModels();
            }

        }
    }


    private void changeModels(){
		other.SetActive (true);
		gameObject.SetActive (false);
		milk.GetComponent<Rigidbody>().isKinematic = false;
	}
}
