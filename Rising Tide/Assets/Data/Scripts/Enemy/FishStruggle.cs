using UnityEngine;
using System.Collections;

public class FishStruggle : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if(GetComponentInParent<Pickupable>().isPickedUp)
		{
			anim.speed = 10f;
		}
		else 
		{
			anim.speed = 1f;
		}
		*/
	}
}
