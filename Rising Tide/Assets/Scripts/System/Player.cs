using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	
	private GameObject player;
	private float playerHealthTotal;
	private float playerHealthCurr;
	public Slider healthBar;
	public Color flashColor = new Color (1f,0f,0f,0.1f);
	public Image hideBar;	
	public Image DamageIndicator;
	public float flashSpeed = 5f;
	//bool damaged;
	bool isAlive;
	

	void Start () {
		//Set initial health of player;
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealthTotal = player.GetComponent<Player_stats>().PlayerHealthMax;
	
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Input.GetKeyUp("x"))
		{
			player.GetComponent<Player_stats>().playerDamage(1f);
			//damage = true;
		}
		
		playerHealthCurr = player.GetComponent<Player_stats>().PlayerCurrHealth;
		healthBar.value = playerHealthCurr;
		
		if(playerHealthCurr <= 0f  && isAlive)
		{
			hideBar.color = Color.Lerp(Color.clear, Color.black, playerHealthCurr/playerHealthTotal);
		}
		
		if (player.GetComponent<Player_stats>().PlayerDmged)
		{
			DamageIndicator.color = flashColor;
		}
		else
		{
			DamageIndicator.color = Color.Lerp(DamageIndicator.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		player.GetComponent<Player_stats>().PlayerDmged = false;
		
		
		

	}

	/*test if UI updates when taking damage, right now just
	reduce health by one.*/
	/*public void simulateDamage(float val){
		damaged = true;
		playerHealthCurr = player.GetComponent<Player_stats>().playerHealthCurr
		playerHealthCurr -= val;
		healthBar.value = playerHealthCurr;
		if(playerHealthCurr <= 0f  && isAlive){
			hideBar.color = Color.Lerp(Color.clear, Color.black, playerHealthCurr/playerHealthTotal);
		}
	}*/
}
