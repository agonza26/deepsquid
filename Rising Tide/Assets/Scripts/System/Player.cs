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

	public CanvasGroup uiCanvas;
	
	//bool damaged;

	bool isAlive;
	

	void Start () {
		//Set initial health of player;
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealthTotal = player.GetComponent<Player_stats>().PlayerHealthMax;
	
		isAlive = true;
		StartCoroutine(hideUI());

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
			showUI();
			StartCoroutine(hideUI());
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

	
	IEnumerator hideUI(){
		uiCanvas.alpha = 255;
		Debug.Log("Before Waiting 5 seconds");
		yield return new WaitForSeconds(5);
		while(uiCanvas.alpha > 0){
			yield return new WaitForSeconds(0.05f);
			Debug.Log(uiCanvas.alpha);
			uiCanvas.alpha -= 0.05f;
			
		}
	}
	public void showUI(){
		uiCanvas.alpha = 255;
	}
	

}
