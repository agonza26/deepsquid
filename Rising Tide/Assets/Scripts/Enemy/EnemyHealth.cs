using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float enemyHealthMax;
	public float enemyHealthCurr;
	public float PlayerHealthRestoreValue;

	// Use this for initialization
	void Start () {
		enemyHealthCurr = enemyHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
	//Debug.Log(enemyHealthCurr);
		if(enemyHealthCurr <= 0)
		{
			Debug.Log(this + " has been defeated");
			gameObject.SetActive(false);
			//Destroy(this);
		}
	}
	
	public void enemyTakeDmg(float dmgReceivedVal)
	{
		enemyHealthCurr -= dmgReceivedVal;
	}
}
