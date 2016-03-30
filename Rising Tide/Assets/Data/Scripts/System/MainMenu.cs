using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void LoadNewGame()
	{
		Debug.Log("LoadNewGame() function running...");
		print ("we are here");
		SceneManager.LoadScene ("Scene 1");
		//way to reload scene SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void QuitGame()
	{
		Debug.Log("QuitGame function running...");
		Application.Quit();
	}
}
