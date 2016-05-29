using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float enemyHealthMax;
	public float enemyHealthCurr;
	public float PlayerHealthRestoreValue;
	private string ecosystem;
	public int prevMod = 0;
	[Range(1, 500)]
	public int hitSoundCounter = 1;
	public AudioSource hitSound;

	// Use this for initialization
	void Start () {
		ecosystem = GetComponent<BasicEnemy> ().ecosystem;
		enemyHealthCurr = enemyHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealthCurr <= 0) {
			print ("die");
			GameObject.Find (ecosystem).GetComponent<EcoPoints> ().Die (gameObject);
		} else if (  (  ( (enemyHealthMax - enemyHealthCurr) %  (hitSoundCounter)) == 0) &&   ( (enemyHealthMax - enemyHealthCurr) /  (hitSoundCounter))  > prevMod )  {
			prevMod =  (int)( (enemyHealthMax - enemyHealthCurr) /  (hitSoundCounter));
			if (hitSound)
				hitSound.Play ();
		}
	}


	public bool enemyTakeDmg(float dmgReceivedVal){
		enemyHealthCurr -= dmgReceivedVal;
		return enemyHealthCurr <= 0;
	}
}
