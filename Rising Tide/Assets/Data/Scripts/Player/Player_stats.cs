using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player_stats : MonoBehaviour {

	public float PlayerHealthMax = 100f;
	private float currHealth;
	public bool PlayerDmged = false;
	public Image healthBar;
	public GameObject healthTooltipText;
	public GameObject tutorialBox;
	private Color lowAlph;
	public AudioSource ding;
	private Color normalAlph;
	public bool isDead;
	public float stamDmgModifier;
	public AudioSource hurtSound;

	public float PlayerCurrHealth(){
		return currHealth;
	}

	// Use this for initialization
	void Start () {
		tutorialBox.SetActive (false);
		currHealth = PlayerHealthMax;
		normalAlph = GetComponent<Renderer>().material.color;
		lowAlph = GetComponent<Renderer>().material.color;
		lowAlph.a = 0.3f;
		isDead = false;
	}




	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = currHealth / PlayerHealthMax;
		if (currHealth <= 0) {
			GetComponent<improved_movement> ().toggleDeathState ();
			isDead = true;
		} else {
			if(Input.GetKeyUp("x") && false)
			{
				playerDamage(1f);
			}
		}

	}



	public void playerDamage(float val)
	{
		if (hurtSound) {
			if(!hurtSound.isPlaying)
				hurtSound.Play ();
		}
		PlayerDmged = true;
		currHealth -= val;
		if(GetComponent<PickupObject>().carrying)
		{
			//GetComponent<Abilities>().stamDmg(stamDmgModifier);
		}
		if (currHealth > PlayerHealthMax)
			currHealth = PlayerHealthMax;
	}








	public void playerRestoreHealth(float val)
	{
		currHealth += val;
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


}
