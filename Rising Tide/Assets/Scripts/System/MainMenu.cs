using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void LoadNewGame()
	{
		Debug.Log("LoadNewGame() function running...");
		Application.LoadLevel("Scene 1");
	}
	
	public void QuitGame()
	{
		Debug.Log("QuitGame function running...");
		Application.Quit();
	}
}
