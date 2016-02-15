using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float atkValue = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision o)
	{
		if(o.gameObject.tag == "Player")
		{
			o.gameObject.GetComponent<Player_stats>().playerDamage(atkValue);
		} 
		else
		{
			return;
		}
	}
}
