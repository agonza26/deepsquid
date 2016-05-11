using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
	
	
	private bool isPause;
	public GameObject pausedInd;
	public GameObject ResumeGameBut;
	public GameObject QuitGameBut;
	public GameObject MenuBezzle;
	public GameObject player;
	public string sliderName = "Slider"; 
	private GameObject Slider;

	void Start  (){
		if(!Slider)
			Slider = GameObject.Find (sliderName);
			GameObject.Find ("Player").GetComponent<improved_movement> ().rotationSpeedMax = Slider.GetComponent<Slider> ().value;

	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape) && !player.GetComponent<Player_stats>().isDead){
			PUPgame();	
		}
		if(isPause)
		{
			Slider.SetActive (true);
			Slider.GetComponent<Slider> ().value = Mathf.Min(GameObject.Find ("Player").GetComponent<improved_movement>().rotationSpeedMax,Slider.GetComponent<Slider> ().maxValue) ;
			ResumeGameBut.SetActive(true);
			QuitGameBut.SetActive(true);
			pausedInd.SetActive(true);
			MenuBezzle.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} 
		else 
		{
			
			Slider.SetActive (false);
			ResumeGameBut.SetActive(false);
			QuitGameBut.SetActive(false);
			pausedInd.SetActive(false);
			MenuBezzle.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
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