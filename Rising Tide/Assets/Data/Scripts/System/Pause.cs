using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	
	private bool isPause;
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown ("p")){
			isPause = !isPause;
			
			if(isPause){
				Time.timeScale = 0;
			}
			else{
				Time.timeScale = 1;
		}
	}
	}
}