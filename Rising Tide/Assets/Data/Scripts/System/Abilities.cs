using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Abilities : MonoBehaviour {

	public ParticleSystem Ink;
	public Transform playerPos;
	public AudioSource ad;
	public ParticleSystem boostPS;

	//public Abilities abilities;
	public float abilitySpeedVal = 1f;
	public float maxStamina = 200;
	public float currStamina = 200;
	public Image staminaBar;
	//0 = speed
	//1 = ink
	//2 = emp
	//3 = current
	public bool[] abilities = new bool[4] {false, true, false, false};
	public bool[] activeAbils = new bool[4]{false, false, false, false};
	//ink is red
	//speed is blue
	//emp is purple
	//current is yellow
	public Image activeIcon;
	public Image speedIcon;
	public Image inkIcon;
	public Image currentIcon;
	public Image empIcon;

	// Use this for initialization
	void Start () {
		speedIcon.enabled = false;
		currentIcon.enabled = false;
		empIcon.enabled = false;
		inkIcon.enabled = true;
		activeIcon.enabled = false;
		StartCoroutine(replenishStam());

	}

	// Update is called once per frame
	void Update () {
		if (!GetComponent<improved_movement> ().isDead) {

			staminaBar.fillAmount = currStamina / maxStamina;
			setActiveAbility ();
	
			if (abilities [1] == true) {
			
				inkIcon.enabled = true;
				if (Input.GetKey ("space") && currStamina >= 5 && activeAbils [1] == true) {
					StartCoroutine (depleteStam (5f));
					newInk ();
				} else {
					Ink.Stop ();
				}
			} else {
			}
			//Controls controlling the speed ability, this is meant to be a default ability on shift
			if (abilities [0] == true) {
				speedIcon.enabled = true;
				if (Input.GetKey ("space") && currStamina >= 5 && activeAbils [0] == true) {
					abilitySpeedVal = 3f;
					StartCoroutine (depleteStam (3f));
					if (Input.GetKeyDown ("space")) 
					{
						bubblesBoost();	
					}
				} else {
					abilitySpeedVal = 1f;
					boostPS.Stop ();
				}
				

			}

		}
	}

	void setActiveAbility(){
		//speed
		if (Input.GetKeyDown ("2")) {
			if (abilities [0] == true) {
				activeIcon.enabled = true;
				for (int i = 0; i < 4; i++) {
					activeAbils [i] = false;
				}
				activeAbils [0] = true;
				activeIcon.sprite = speedIcon.sprite;
				activeIcon.color = speedIcon.color;
			}
		}
		//ink
		else if (Input.GetKeyDown ("1")) {

			if (abilities [1] == true) {
				activeIcon.enabled = true;
				for (int i = 0; i < 4; i++) {
					activeAbils [i] = false;
				}
				activeAbils [1] = true;
				activeIcon.sprite = inkIcon.sprite;
				activeIcon.color = inkIcon.color;
			}
		}
		//emp
		else if (Input.GetKeyDown ("3")) {
			if (abilities [2] == true) {
				activeIcon.enabled = true;
				for (int i = 0; i < 4; i++) {
					activeAbils [i] = false;
				}
				activeAbils [2] = true;
				activeIcon.sprite = currentIcon.sprite;
				activeIcon.color = currentIcon.color;
			}
		}
		//current
		else if (Input.GetKeyDown ("4")) {
			if (abilities [3] == true) {
				activeIcon.enabled = true;
				for (int i = 0; i < 4; i++) {
					activeAbils [i] = false;
				}
				activeAbils [3] = true;
				activeIcon.sprite = empIcon.sprite;
				activeIcon.color = empIcon.color;
			}
		} else {
		}
	}

	//Inking 
	void newInk(){
		Ink.transform.position = playerPos.transform.position - playerPos.transform.forward * 5f;
		Ink.transform.rotation = playerPos.transform.rotation;
		//Quaternion inkRotation = Ink.transform.rotation; not used
		Ink.Play();
	}
	
	void bubblesBoost()
	{
		boostPS.transform.position = playerPos.transform.position;
		//boostPS.transform.Translate (Vector3.forward * 5);
		boostPS.transform.rotation = playerPos.transform.rotation;
		//boostPS.transform.forward *= -1f;
		//Quaternion inkRotation = Ink.transform.rotation;
		ad.Play();
		boostPS.Emit(35);
	}

	//Coroutine to wait x amount of time
	IEnumerator replenishStam(){
		while (true) {
			if (currStamina < maxStamina) {
				currStamina = currStamina + 20;
				yield return new WaitForSeconds (2f);
			} else {
				yield return null;
			}
		}
	}
	IEnumerator depleteStam(float cost){
		
		yield return new WaitForSeconds(0.1f);
		if (currStamina < 0) {
		} else {
			currStamina = currStamina - cost;
		}
	}





}

