using UnityEngine;
using System.Collections;

public class Player_stats : MonoBehaviour {
	
	public float PlayerHealthMax = 10f;
	public float PlayerOverhealthMax;
	public float PlayerCurrHealth;
	public bool PlayerDmged;

	// Use this for initialization
	void Start () {
		PlayerCurrHealth = PlayerHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void playerDamage(float val)
	{
		PlayerDmged = true;
		PlayerCurrHealth -= val;
	}
}
