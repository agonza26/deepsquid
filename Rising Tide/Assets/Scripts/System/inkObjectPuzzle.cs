using UnityEngine;
using System.Collections;

public class inkObjectPuzzle : MonoBehaviour {

    public bool activated;
	public bool hasAnOrb;
    float timer = 100;
    float countdown;
	private GameObject proj;

    //public Material activeMaterial;
    //public Material defaultMaterial;

    // Use this for initialization
    void Start () {
        countdown = timer;

    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(activated);
        //Debug.Log(countdown);

        if (activated)
        {
            if (countdown >= 0)
            {
                countdown--;
				Debug.Log (timer);
				GetComponentInChildren<MuralPuzzleSwitchImage> ().ChangeToInked (1);
                //this.GetComponent<Renderer>().material = activeMaterial;
            }
            else if (countdown <= 0)
            {
                activated = false;
                countdown = timer;
				GetComponentInChildren<MuralPuzzleSwitchImage> ().ChangeToInked (0);
                //this.GetComponent<Renderer>().material = defaultMaterial;
            }
        }
        /*if (this.gameObject.tag == "inkMural")
        {

        }
        else if (this.gameObject.tag == "inkOrb")
        {

        }*/
	
	}
	
	public void toggleHasAnOrb()
	{
		hasAnOrb = true;
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "AbilityInk")
        {
            if (!activated) activated = true;
        }
    }
}
