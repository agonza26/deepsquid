using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCanvasManager : MonoBehaviour {
	
	public CanvasGroup thisCanvas;
	public GameObject player;
	public Image deathImage;
	public Button restartBut;
	public Button quitBut;

	public GameObject t2;
	public GameObject t1;
	// Use this for initialization
	void Start () {
		thisCanvas.interactable = false;
		deathImage.CrossFadeAlpha(0f, 0, true);
		Color rbTemp = restartBut.GetComponent<Image>().color;
		rbTemp.a = 0f;
		restartBut.GetComponent<Image>().color = rbTemp;	
		quitBut.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);

		t1.SetActive (false);
		t2.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (player.GetComponent<Player_stats> ().isDead) {
			t1.SetActive (true);
			t2.SetActive (true);
			deathImage.CrossFadeAlpha (255f, 500f, false);
			thisCanvas.interactable = true;
		} else {
			t1.SetActive (false);
			t2.SetActive (false);
		}

		if(deathImage.color.a == 255f)
		{
			
			restartBut.GetComponent<Image>().CrossFadeAlpha(255f, 250f, false);
			quitBut.GetComponent<Image>().CrossFadeAlpha(255f, 250f, false);
		}
	}
}
