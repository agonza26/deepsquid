using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float enemyHealthMax;
	public float enemyHealthCurr;

	// Use this for initialization
	void Start () {
		enemyHealthCurr = enemyHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void enemyTakeDmg(float dmgReceivedVal)
	{
		enemyHealthCurr -= dmgReceivedVal;
	}
}
