using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void StartGame()
	{
		Application.LoadLevel("Scene 1");
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
