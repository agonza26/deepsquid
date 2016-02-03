using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float playerHealthTotal;
	public float playerHealthCurr;
	public Slider healthBar;
	public Color flashColor = new Color (1f,0f,0f,0.1f);
	public Image hideBar;	
	public Image DamageIndicator;
	public float flashSpeed = 5f;
	bool damaged;
	bool isAlive;
	

	void Start () {
		//Set initial health of player;
		playerHealthTotal = 10f;
		playerHealthCurr = playerHealthTotal;	
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (damaged){
			DamageIndicator.color = flashColor;
		}
		else{
			DamageIndicator.color = Color.Lerp(DamageIndicator.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
		if(Input.GetKeyUp("x")){
			simulateDamage(1f);
		}

	}

	/*test if UI updates when taking damage, right now just
	reduce health by one.*/
	public void simulateDamage(float val){
		damaged = true;
		playerHealthCurr -= val;
		healthBar.value = playerHealthCurr;
		if(playerHealthCurr <= 0f  && isAlive){
			hideBar.color = Color.Lerp(Color.clear, Color.black, playerHealthCurr/playerHealthTotal);
		}
	}
}
