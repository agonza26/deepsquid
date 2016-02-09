﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Abilities : MonoBehaviour {
	public Material playerMat;
	public Material camoMat;
	public ParticleSystem Ink;
	public Transform playerPos;
	//if its true, that means its on CD and cannot be used, if false then usable.
	Color camoColor = new Color(0.0f, 0.0f, 0.0f, 0.1f);
	Color nonCamoColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	Color lerpedCamo;

	public float inkCDTimer = 0;
	public float inkCD = 10.5f;
	// Use this for initialization
	void Start () {
		camoColor.a = 0.1f;
		nonCamoColor = GetComponent<Renderer>().material.color;
		nonCamoColor.a = 1f;
	
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
		if (Input.GetKey ("t")) {
			StartCoroutine(camouflage (camoColor, 1.0f));
		} else {
			StartCoroutine(camouflage (nonCamoColor, 1.0f));
		}
			
	}
	//Inking 
	void newInk(){
		
		Ink.transform.position = playerPos.transform.position;
		//Ink.sizeOverLifetime.enabled = true;
		ParticleSystem.SizeOverLifetimeModule sz = Ink.sizeOverLifetime;
		sz.enabled = true;
		Ink.Play ();
	}
	//Camoflouage
	void camo(){
		//camoColor.a = 0.1f;
		//nonCamoColor.a = 1.0f;
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


}
