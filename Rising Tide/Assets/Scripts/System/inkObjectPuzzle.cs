using UnityEngine;
using System.Collections;

public class inkObjectPuzzle : MonoBehaviour {

    public bool activated;
	public bool hasAnOrb;
    public float timer = 150;
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

				GetComponentInChildren<MuralPuzzleSwitchImage> ().ChangeToInked (1);
                //this.GetComponent<Renderer>().material = activeMaterial;
            }
            else if (countdown <= 0)
            {
				activated = false;
				GetComponentInChildren<MuralPuzzleSwitchImage> ().ChangeToInked (0);
                countdown = timer;
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
            activated = true;
        }
    }
}
