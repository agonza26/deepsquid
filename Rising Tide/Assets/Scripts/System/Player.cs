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
	public CanvasGroup uiCanvas;
	
	bool damaged;
	bool isAlive;
	

	void Start () {
		//Set initial health of player;
		playerHealthTotal = 10f;
		playerHealthCurr = playerHealthTotal;	
		isAlive = true;
		StartCoroutine(hideUI());

	}
	
	// Update is called once per frame
	void Update () {
		
		if (damaged){
			DamageIndicator.color = flashColor;
			showUI();
			StartCoroutine(hideUI());
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
	
	IEnumerator hideUI(){
		uiCanvas.alpha = 255;
		//Debug.Log("Before Waiting 5 seconds");
		yield return new WaitForSeconds(5);
		while(uiCanvas.alpha > 0){
			yield return new WaitForSeconds(0.05f);
			//Debug.Log(uiCanvas.alpha);
			uiCanvas.alpha -= 0.05f;
			
		}
	}
	public void showUI(){
		uiCanvas.alpha = 255;
	}
	
}
