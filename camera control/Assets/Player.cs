using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	public float playerHealth;
	public Text healthText;
	public bool fullHealth;
	// Use this for initialization
	void Start () {
		playerHealth = 10f;
		healthDisplay(playerHealth);
	}
	
	// Update is called once per frame
	void Update () {
		healthDisplay(playerHealth);
		simulateDamage();
	}
	// Displays health
	void healthDisplay(float health){
		if (health != 0.0f){
			healthText.text = "Health: ";
			for(float i = 0.0f; i < health; i++){
				healthText.text = healthText.text + "x";
			}
			
		}
	}
	/*test if UI updates when taking damage, right now just
	reduce health by one.*/
	void simulateDamage(){
		if(Input.GetKeyUp("x")){
			playerHealth--;
			
		}
	}
}
