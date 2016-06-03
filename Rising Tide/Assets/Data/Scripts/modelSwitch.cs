using UnityEngine;
using System.Collections;

public class modelSwitch : MonoBehaviour {

	public GameObject other;
	public bool isFirst = false;

	// Use this for initialization
	void Start () {
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
			if (o.gameObject.GetComponent<Pickupable> ().isThrown ()) {
				/*print ("here in is Thrown");
				o.gameObject.GetComponent<Pickupable> ().changeThrown ();*/
				if (GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().posInDialogue == 3) {
					changeModels ();
					GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().isGlassBroken = true;
				}
			}

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
                GameObject.FindGameObjectWithTag("borkVisualCollider").GetComponent<TutorialObject>().isGlassBroken = true;
            }

        }
    }


    private void changeModels(){
		other.SetActive (true);
		gameObject.SetActive (false);
	}
}
