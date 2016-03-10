using UnityEngine;
using System.Collections;

public class MuralPuzzleSwitchImage : MonoBehaviour {

	public Texture[] frames;
	public int frameIndex = 0;
	private Projector projector;
	private bool inked = false;

	// Use this for initialization
	void Start () 
	{
		projector = GetComponent<Projector> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		projector.material.SetTexture ("_ShadowTex", frames [frameIndex]);
	}

	public void ChangeToInked(int newInd)
	{
		frameIndex = newInd;
	}

}
