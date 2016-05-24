﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player_stats : MonoBehaviour {

	public float PlayerHealthMax = 10f;
	public float PlayerOverhealthMax;
	private bool isTextActive = true;
	public float PlayerCurrHealth;
	public float restartDelay = 5f;
	public bool PlayerDmged;
	public float PlayerDmgOutput = 30f;
	public Image healthBar;
	public GameObject healthTooltipText;
	public GameObject tutorialBox;
	private Color lowAlph;
	public AudioSource ding;
	private Color normalAlph;
	public bool isDead;
	public float stamDmgModifier;

	// Use this for initialization
	void Start () {
		tutorialBox.SetActive (false);
		PlayerCurrHealth = PlayerHealthMax;
		normalAlph = GetComponent<Renderer>().material.color;
		lowAlph = GetComponent<Renderer>().material.color;
		lowAlph.a = 0.3f;
		isDead = false;
	}

	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = PlayerCurrHealth / PlayerHealthMax;
		if (PlayerCurrHealth <= 0) {
			GetComponent<improved_movement> ().toggleDeathState ();
			isDead = true;
		} else {
			if(Input.GetKeyUp("x"))
			{
				playerDamage(1f);
			}
		}if (PlayerCurrHealth < PlayerHealthMax) {
			if (isTextActive == true) {
				//ding.Play ();
				//StartCoroutine (waitToTurnOff (5f));
			}
		}





	}


	void OnCollisionEnter(Collision other) {
		

	}

	public void playerDamage(float val)
	{
		PlayerDmged = true;
		PlayerCurrHealth -= val;
		if(GetComponent<PickupObject>().carrying)
		{
			GetComponent<Abilities>().stamDmg(val*stamDmgModifier);
		}
		if (PlayerCurrHealth > PlayerHealthMax)
			PlayerCurrHealth = PlayerHealthMax;
	}

	public void playerRestoreHealth(float val)
	{
		PlayerCurrHealth += val;
	}


	public void changePlayerAlphaDown()
	{
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, lowAlph, 5f * Time.deltaTime);		
	}

	public void changePlayerAlphaUp()
	{
		if(GetComponent<Renderer>().material.color.a > normalAlph.a)
		{
			return;
		}
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, normalAlph, 5f * Time.deltaTime); 
	}

	public float giveDmg()
	{
		return PlayerDmgOutput;
	}

	
	IEnumerator waitToTurnOff(float x){
		healthTooltipText.SetActive (true);
		tutorialBox.SetActive (true);
		yield return new WaitForSeconds(x);
		isTextActive = false;
		tutorialBox.SetActive (false);
		healthTooltipText.SetActive (false);
		ding.Stop ();
	}
}
