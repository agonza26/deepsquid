using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject player;

	public Slider healthBar;
	public Color flashColor = new Color (1f,0f,0f,0.1f);
	public Image DamageIndicator;
	public float flashSpeed = 5f;
	bool showingUI = true;


	public CanvasGroup uiCanvas;


	

	void Start () {
		//Set initial health of player;


		//StartCoroutine (hideUI ());


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (showingUI == false) {
				showUI ();
				showingUI = true;
			} else {
				hideUI ();
				showingUI = false;
			}


			//break;
		}
		

		if (player.GetComponent<Player_stats>().PlayerDmged)
		{
			DamageIndicator.color = flashColor;
			//showUI();
			//StartCoroutine(hideUI());
		}
		else
		{
			DamageIndicator.color = Color.Lerp(DamageIndicator.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		player.GetComponent<Player_stats>().PlayerDmged = false;

	}




	public void hideUI(){
		
			uiCanvas.alpha = 0;
		/*
			if (showingUI == true) {
				
				while (uiCanvas.alpha > 0) {
					if (keyPressed) {
						keyPressed = false;
						break;
					}
					yield return new WaitForSeconds (0.05f);
					uiCanvas.alpha -= 0.05f;
					if (uiCanvas.alpha >= 0.05) {
						showingUI = false;
					}
			
				}
			} else {
				yield return null;
			}*/

	}




	public void showUI(){
		//showingUI = true;
		uiCanvas.alpha = 255;
	}
	

}
