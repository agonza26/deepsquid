using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Abilities : MonoBehaviour {
	public Material playerMat;
	public Material camoMat;
	public ParticleSystem Ink;
	public Transform playerPos;
	//if its true, that means its on CD and cannot be used, if false then usable.
	Color color;
	public float inkCDTimer = 0;
	public float inkCD = 5;
	// Use this for initialization
	void Start () {
		color = GetComponent<Renderer>().material.color;
		color.a = 1f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("space") && Time.time > inkCDTimer) {
			inkCDTimer = Time.time + inkCD;
			newInk ();

		} else if (Input.GetKeyDown ("space") && Time.time < inkCDTimer) {
			Debug.Log ("Ink is on CD");
		} else {
		}
		/*while(Input.GetKey("t")){
			camo();
		}*/
			
	}

	void newInk(){
		
		Ink.transform.position = playerPos.transform.position;
		//Ink.sizeOverLifetime.enabled = true;
		ParticleSystem.SizeOverLifetimeModule sz = Ink.sizeOverLifetime;
		sz.enabled = true;
		Ink.Play ();
	}
	
	void camo(){
		//GetComponent<Renderer>().material.color;
		color.a = 0.1f;
		GetComponent<Renderer>().material.SetColor("_Color", color);
		
	}


}
