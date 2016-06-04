using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Abilities : MonoBehaviour {

	public ParticleSystem Ink;
	public ParticleSystem EMPps;
	public Transform playerPos;
	public AudioSource BoostSound;
	public AudioSource EMPsound;
	public AudioSource InkSound;
	public AudioSource CurrentAbilSound;
	public ParticleSystem boostPS;
	public int boostParticles = 35;
	public GameObject waveBullet;
	private int replenishStamCounter = 0;
	public float replenishStamTimer = 0.05f;
	private int depleteStamCounter = 0;
	public float depleteStamTimer = 0.05f;

	//public Abilities abilities;
	public bool firstTimeInking = false;
	public bool firstTimeSpeeding = false;
	public bool firstTimeSanic = false;
	public bool firstTimeEmp = false;




	public float abilitySpeedVal = 1f;
	public float maxStamina = 200;
	public float currStamina = 200;
	public float stamRegenVal = 1f;
	public Image staminaBar;
	public bool pauseStam = false;
	public float depStamAmt = 1f;





	//0 = speed
	//1 = ink
	//2 = emp
	//3 = current
	public bool[] abilities = new bool[4] {false, false, false, false};
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



	public float speedStaminaCost = 1.5f;
	public float inkStaminaCost = 6f;
	public float waveStaminaCost = 50f;
	public float empStaminaCost = 175f;


	private empGrower EMPc;

	// Use this for initialization
	void Start () {
		currStamina = maxStamina;
		speedIcon.enabled = false;
		currentIcon.enabled = false;
		empIcon.enabled = false;
		inkIcon.enabled = false;
		activeIcon.enabled = false;
//		StartCoroutine(replenishStam());
		EMPc= GameObject.FindGameObjectWithTag ("EMP").GetComponent<empGrower> ();

	}

	private bool canReplenishStam(){
		return (pauseStam == false && replenishStamCounter < 3 && currStamina < maxStamina);
	}

	private bool canDepleteStam(){
		return (pauseStam == false && depleteStamCounter < 2 && currStamina >0);
	}





	// Update is called once per frame
	void Update () {
		

		if (Input.GetKey ("h")) {
			pauseStam = false;
			currStamina = 0;

		}

		if (!GetComponent<improved_movement> ().isDead) {
			if(!GetComponent<PickupObject>().carrying){
				if(canReplenishStam()){
					StartCoroutine(replenishStam());
				}
			} else {
				if (GetComponent<PickupObject> ().carriedObject.tag == "Enemy") {
					if(canDepleteStam())
						StartCoroutine(depleteStam(depStamAmt));
				}
			}




			setActiveAbility ();

	
			if (abilities [1] == true && !GetComponent<PickupObject>().carrying) {
			
				inkIcon.enabled = true;
				if (Input.GetKey ("space") && currStamina >= inkStaminaCost && activeAbils [1] == true) {
					firstTimeInking = true;
					pauseStam = true;
					simpleDeplete(inkStaminaCost);
					newInk ();
					if(InkSound)
						InkSound.Play();
				} else {
					pauseStam = false;
					Ink.Stop ();
				}
			}



			//Controls controlling the speed ability, this is meant to be a default ability on shift
			if (abilities [0] == true) {
				speedIcon.enabled = true;
				if (Input.GetKey ("space") && currStamina >= speedStaminaCost && activeAbils [0] == true && !GetComponent<PickupObject>().carrying) {
					firstTimeSpeeding = true;
					pauseStam = true;
					abilitySpeedVal = 3f;
					simpleDeplete(speedStaminaCost);
					if (Input.GetKeyDown ("space")) 
					{
						bubblesBoost();	
					}
				} else {
					abilitySpeedVal = 1f;
					boostPS.Stop ();
					pauseStam = false;
				}
				

			}
			
			if(abilities[3] == true)
			{
				empIcon.enabled = true;
				if(Input.GetKeyDown("space") && !GetComponent<PickupObject>().carrying && currStamina >= empStaminaCost && activeAbils[3] && EMPc.coroutineDone)
				{
					firstTimeEmp = true;
					//pauseStam = true;
					simpleDeplete(empStaminaCost);
					EMPps.Emit(1);
					EMPc.startGrowing ();
					if(EMPsound)
						EMPsound.Play();
				} else if (Input.GetKeyUp("space"))
				{
					//EMPps.Stop();
					//pauseStam = false;
				}
			}
			
			if(abilities[2] == true)
			{
				currentIcon.enabled = true;
				if(Input.GetKeyDown("space") && !GetComponent<PickupObject>().carrying && currStamina >= waveStaminaCost && activeAbils[2])
				{
					firstTimeSanic = true;
					simpleDeplete(waveStaminaCost);
					if(CurrentAbilSound)
						CurrentAbilSound.Play();
					Instantiate(waveBullet, transform.position, transform.rotation *  Quaternion.AngleAxis(180, Vector3.up));
				}
			}

		}

		staminaBar.fillAmount = currStamina / maxStamina;
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
		if(BoostSound)
			BoostSound.Play();
		boostPS.Emit(boostParticles);
	}

	//Coroutine to wait x amount of time
	IEnumerator replenishStam(){
		replenishStamCounter++;


		if(Time.timeScale != 0){
				currStamina += Mathf.Min(stamRegenVal, maxStamina - currStamina) ;
				yield return new WaitForSeconds (replenishStamTimer);
					
			//}
		}
		replenishStamCounter--;
	}




	private void simpleDeplete( float cost){
		if (currStamina-cost > 0) {
			currStamina -= cost;
		} else {
			currStamina = 0;
		}


	}







	public IEnumerator depleteStam(float cost){
		depleteStamCounter++;
		if (Time.timeScale != 0) {
			
			if (currStamina-cost > 0) {
				currStamina -= cost;
			} else {
				currStamina = 0;
			}

			yield return new WaitForSeconds (depleteStamTimer);

		}
		depleteStamCounter--;
	}










}

