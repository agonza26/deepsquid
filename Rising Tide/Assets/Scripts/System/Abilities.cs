using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Abilities : MonoBehaviour {
	public bool procured;

	public ParticleSystem Ink;
	public Transform playerPos;

	//if its true, that means its on CD and cannot be used, if false then usable.
	Color camoColor = new Color(0.0f, 0.0f, 0.0f, 0.1f);
	Color nonCamoColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	Color lerpedCamo;
	//Enemy
	public simple_movement inkCharge;
	//public GameObject inkAbilityObject;
	//public GameObject speedAbilityObject;
	public GameObject testObject;
	//public Abilities abilities;
	public bool inkCloudCD = false;
	public float inkCD = 5.0f;
	public float inkCDTimer = 0f;
	public float abilitySpeedVal = 1f;
    public bool[] abilities;


	// Use this for initialization
	void Start () {
		//abilities = abilityObject.GetComponent<AbilityProcurement> ().abilities;

	}

	// Update is called once per frame
	void Update () {
		abilities = testObject.GetComponent<AbilityProcurement> ().abilities;
		Debug.Log("in abilities: " + abilities[0] + ", " + abilities[1]);
		//Controls inking when space is pressed and within the time CD

		if (Input.GetKeyDown ("1") && Time.time > inkCDTimer && abilities[1] == true) {
			//Debug.Log ("This is not happening");
			inkCDTimer = Time.time + inkCD;
			inkCharge = GetComponent<simple_movement>();
			StartCoroutine(inkCharge.inkJump());
			newInk ();

		}  else {
		}
		//Controls controlling the speed ability, this is meant to be a default ability on shift
		if (Input.GetKey (KeyCode.LeftShift) && abilities[0] == true) {
			abilitySpeedVal = 3f;
		} else {
			abilitySpeedVal = 1f;
		}



	}


	//Inking 
	void newInk(){

		Ink.transform.position = playerPos.transform.position;

		ParticleSystem.SizeOverLifetimeModule sz = Ink.sizeOverLifetime;
		sz.enabled = true;
		Ink.Play ();
	}
	//Camoflouage
	void camo(){
		lerpedCamo = Color.Lerp (nonCamoColor, camoColor, 5f);
		GetComponent<Renderer>().material.SetColor("_Color", lerpedCamo);

	}
	//Camoflouage
	void unCamo(){
		//camoColor.a = 0.1f;
		//nonCamoColor.a = 1.0f;
		lerpedCamo = Color.Lerp (camoColor, nonCamoColor, 5f);
		GetComponent<Renderer>().material.SetColor("_Color", lerpedCamo);

	}
	IEnumerator camouflage(Color alphaVal, float alphaTime){
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / alphaTime) {
			Color newCamoVal = GetComponent<Renderer> ().material.color;
			lerpedCamo = Color.Lerp (newCamoVal, alphaVal, i);
			GetComponent<Renderer>().material.SetColor("_Color", lerpedCamo);
			yield return null;
		}
	}

	/*public void SetAbilityArray(int ArPos)
	{
		abilities [ArPos] = true;	
	}
*/
}

