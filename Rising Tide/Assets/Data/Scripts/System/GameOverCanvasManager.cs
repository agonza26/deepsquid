using UnityEngine;
using System.Collections;

public class GameOverCanvasManager : MonoBehaviour {
	
	public CanvasGroup thisCanvas;
	public GameObject player;
	bool playerDead = false;
	
	// Use this for initialization
	void Start () {
		thisCanvas.interactable = false;
		thisCanvas.alpha = 0;
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(player.GetComponent<Player_stats>().PlayerCurrHealth <= 0)
		{
			playerDead = true;
		}
		if(playerDead && thisCanvas.alpha < 255)
		{
			thisCanvas.alpha += Time.deltaTime;
		}
	}
}
