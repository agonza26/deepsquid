using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {
	
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey("enter"))
        {
			if(player.GetComponent<Player_stats>().PlayerCurrHealth <= 0)
			{
				SceneManager.LoadScene("Scene 1");
			}
        }
	
	}
}
