using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCanvasManager : MonoBehaviour {
	
	public CanvasGroup thisCanvas;
	public GameObject player;
	public Image deathImage;
	public Button restartBut;
	public Button quitBut;

	// Use this for initialization
	void Start () {
		thisCanvas.interactable = false;
		deathImage.CrossFadeAlpha(0f, 0, true);
		Color rbTemp = restartBut.GetComponent<Image>().color;
		rbTemp.a = 0f;
		restartBut.GetComponent<Image>().color = rbTemp;	
		quitBut.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(player.GetComponent<Player_stats>().isDead)
		{
			deathImage.CrossFadeAlpha(255f, 500f, false);
			thisCanvas.interactable = true;
		}
		
		if(deathImage.color.a == 255f)
		{
			restartBut.GetComponent<Image>().CrossFadeAlpha(255f, 250f, false);
			quitBut.GetComponent<Image>().CrossFadeAlpha(255f, 250f, false);
		}
	}
}
