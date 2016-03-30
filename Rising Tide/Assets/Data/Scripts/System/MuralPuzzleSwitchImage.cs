using UnityEngine;
using System.Collections;

public class MuralPuzzleSwitchImage : MonoBehaviour {

	public Texture[] frames;
	public int frameIndex = 0;
	private Projector projector;

	// Use this for initialization
	void Start () 
	{
		projector = GetComponent<Projector> ();

	}
	
	// Update is called once per frame
	/*void FixedUpdate () 
	{
		projector.material.SetTexture ("_ShadowTex", frames [frameIndex]);
	}*/

	public void ChangeToInked(int newInd)
	{
		frameIndex = newInd;
		projector.material.SetTexture ("_ShadowTex", frames [frameIndex]);
	}

}
