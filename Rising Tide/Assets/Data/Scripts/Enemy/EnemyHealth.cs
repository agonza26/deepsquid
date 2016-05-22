using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float enemyHealthMax;
	public float enemyHealthCurr;
	public float PlayerHealthRestoreValue;
	private string ecosystem;


	private float eHM;
	private float eHC;
	private float PHR;


	public AudioSource t;

	// Use this for initialization
	void Start () {
		ecosystem = GetComponent<BasicEnemy> ().ecosystem;
		enemyHealthCurr = enemyHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
	//Debug.Log(enemyHealthCurr);s
		if(enemyHealthCurr <= 0)
		{
			//t.Play ();
			GameObject.Find (ecosystem).GetComponent<EcoPoints> ().Die (gameObject);
		}
	}
	
	public bool enemyTakeDmg(float dmgReceivedVal)
	{
		enemyHealthCurr -= dmgReceivedVal;

		return enemyHealthCurr <= 0;
	}

	public void Reset(){
		enemyHealthMax = eHM;
		enemyHealthCurr = eHC;
		PlayerHealthRestoreValue = PHR;
	}



}
