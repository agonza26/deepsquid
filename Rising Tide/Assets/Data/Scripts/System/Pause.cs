using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Pause : MonoBehaviour {


	private bool isPause;
	private GameObject pausedInd;
	private GameObject deathInd;
	private GameObject ResumeGameBut;
	private GameObject RestartBut;
	private GameObject QuitGameBut;
	//private GameObject MenuBezzle;
	private GameObject player;
	private GameObject MouseSlideText;
	public string sliderName = "Slider"; 
	private GameObject Slider;

	void Start  (){
		if(Application.loadedLevelName != "MainMenuScene")
		{
			if(!Slider)
			{
				Slider = GameObject.Find (sliderName);
			}
			GameObject.Find ("Player").GetComponent<improved_movement> ().rotationSpeedMax = Slider.GetComponent<Slider> ().value;
			pausedInd = GameObject.Find ("PausedInd");
			deathInd = GameObject.Find("playerded");
			ResumeGameBut = GameObject.Find ("ResumeButton");
			RestartBut = GameObject.Find ("DeadRestartBut");
			QuitGameBut = GameObject.Find ("QuitButton");
			//MenuBezzle = GameObject.Find ("MenuBezzle");
			player = GameObject.Find ("Player");
			MouseSlideText = GameObject.Find ("MouseSliderText");
			deathInd.GetComponent<Image> ().CrossFadeAlpha (0, 0.1f, true);
			deathInd.SetActive (false);
		}

	}
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName != "MainMenuScene")
		{
			if(Input.GetKeyDown (KeyCode.Escape) && !player.GetComponent<Player_stats>().isDead)
			{
				PUPgame();	
			}
			if(isPause)
			{
				Slider.SetActive (true);
				Slider.GetComponent<Slider> ().value = Mathf.Min(GameObject.Find ("Player").GetComponent<improved_movement>().rotationSpeedMax,Slider.GetComponent<Slider> ().maxValue) ;
				ResumeGameBut.SetActive(true);
				RestartBut.SetActive (true);
				QuitGameBut.SetActive(true);
				pausedInd.SetActive(true);
				//MenuBezzle.SetActive(true);
				MouseSlideText.SetActive (true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			} 
			else 
			{
				MouseSlideText.SetActive (false);
				Slider.SetActive (false);
				ResumeGameBut.SetActive(false);
				RestartBut.SetActive (false);
				QuitGameBut.SetActive(false);
				pausedInd.SetActive(false);
				//MenuBezzle.SetActive(false);
				if (!player.GetComponent<Player_stats> ().isDead) 
				{
					Cursor.lockState = CursorLockMode.Locked;	
					Cursor.visible = false;
				}
			}

			if (player.GetComponent<Player_stats> ().isDead) 
			{
				deathInd.SetActive (true);
				int a = 1;
				//isPause = true;
				//ResumeGameBut.SetActive(true);
				RestartBut.SetActive (true);
				QuitGameBut.SetActive(true);
				pausedInd.SetActive(false);
				//MenuBezzle.SetActive(true);
				Time.timeScale = 0.25f;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				deathInd.GetComponent<Image> ().CrossFadeAlpha (a, 2f, true);
				if (a <= 255) 
				{
					a += 1;
				}
			}
		}
	}



	public void PUPgame()
	{
		isPause = !isPause;

		if(isPause){
			Time.timeScale = 0;
		}
		else{
			Time.timeScale = 1;
		}
	}

	public void restartGame()
	{
		if(!player.GetComponent<Player_stats>().isDead)
		{
			//load the scene again here
		}
	}

}