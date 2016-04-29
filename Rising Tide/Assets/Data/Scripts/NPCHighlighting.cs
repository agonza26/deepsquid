using UnityEngine;
using System.Collections;

public class NPCHighlighting : MonoBehaviour {
	public Material[] mats = new Material[2];
	// Use this for initialization
	void Start () {
		mats [0] = GetComponentInChildren<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMatToNml()
	{
		if (mats [0]) {
			if (transform.childCount > 0) {
				GetComponentInChildren<Renderer> ().material = mats [0];
			} else {
				gameObject.GetComponent<Renderer> ().material = mats [0];
			}
		} 
	}

	public void changeMatToHL()
	{
		if (mats [1]) {
			if (transform.childCount > 0) {
				GetComponentInChildren<Renderer> ().material = mats [1];
			} else {
				gameObject.GetComponent<Renderer> ().material = mats [1];
			}
		} 
	}
}
