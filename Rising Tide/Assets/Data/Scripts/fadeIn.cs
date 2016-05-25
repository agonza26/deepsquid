using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour {

	// Use this for initialization
	public Image fadeInnow;

	public Color startColor = Color.black;
	public Color lerpedColor = Color.clear;
	void Start () {
		startColor = fadeInnow.color;
	}
	
	// Update is called once per frame
	void Update () {
		
		fadeInnow.color = Color.Lerp (startColor, lerpedColor, Time.time*1.0f);
		if (fadeInnow.color == Color.clear) {
			fadeInnow.enabled = false;
		}
	}
}
