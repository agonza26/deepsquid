using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {

	private Button ExitBut;
	private Button RestartBut;
	private GameObject SplashScreenBezzle;
	private GameObject SplashNoButton;
	private GameObject ExitAYS; //AYS = are you sure? (splash screen)
	private GameObject RestartAYS;
	private GameObject AYStext;
	public bool AYSactive = false;

	// Use this for initialization
	void Start () {
		if(SceneManager.GetActiveScene().name != "MainMenuScene")
		{
			ExitBut = GameObject.Find("QuitButton").GetComponent<Button>();
			RestartBut = GameObject.Find("DeadRestartBut").GetComponent<Button>();
			SplashScreenBezzle= GameObject.Find("AreYouSure");
			SplashNoButton = GameObject.Find("No");
			ExitAYS = GameObject.Find("QuitCheckButton"); //AYS = are you sure? (splash screen)
			RestartAYS = GameObject.Find("RestartCheckButton");
			AYStext = GameObject.Find("AreYouSureText");
			SplashScreenBezzle.SetActive(false);
			SplashNoButton.SetActive(false);
			ExitAYS.SetActive(false);
			RestartAYS.SetActive(false);
			AYStext.SetActive(false);
		}

	
	}
	
	//when called, will bring up the splash YES or NO. Distinction is for different buttons
	public void RestAYS()
	{
		SplashScreenBezzle.SetActive(true);
		RestartAYS.SetActive(true);
		SplashNoButton.SetActive(true);
		AYStext.SetActive(true);
		ExitBut.interactable = false;
		RestartBut.interactable = false;
		AYSactive = true;
	}
	
	//when called, will bring up the splash YES or NO. this is for the quit buttons
	public void QuitAYS()
	{
		SplashScreenBezzle.SetActive(true);
		ExitAYS.SetActive(true);
		SplashNoButton.SetActive(true);
		AYStext.SetActive(true);
		ExitBut.interactable = false;
		RestartBut.interactable = false;
		AYSactive = true;
	}
	
	//should the player say NO to restarting/quitting the game, should bring back the other options
	public void ReturnToOptions()
	{
		SplashScreenBezzle.SetActive(false);
		RestartAYS.SetActive(false);
		ExitAYS.SetActive(false);
		SplashNoButton.SetActive(false);
		AYStext.SetActive(false);
		ExitBut.interactable = true;
		RestartBut.interactable = true;
		AYSactive = false;
	}

	
	// Function call exits the App
	public void exitApp()
	{
		Application.Quit();
	}
	
	// Function call reloads the scene, essentially restarting the game.
	public void restartGame()
	{
		SceneManager.UnloadScene ("Scene 1");
		SceneManager.LoadScene ("Scene 1");
	}
}
