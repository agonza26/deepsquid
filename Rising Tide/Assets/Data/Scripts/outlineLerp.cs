using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class outlineLerp : MonoBehaviour {

	// Use this for initialization
	public Image outlines;
	public Image outlines1;
	public Image outlines2;
	public Image outlines3;
	public Image outlines4;
	public Color endColor = Color.red;
	public Color lerpedColor = Color.white;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		lerpedColor = Color.Lerp (Color.white, endColor, Mathf.PingPong (Time.time, 1));
		outlines1.color = lerpedColor;
		outlines2.color = lerpedColor;
		outlines3.color = lerpedColor;
		outlines4.color = lerpedColor;
		outlines.color = lerpedColor;

	}
}
