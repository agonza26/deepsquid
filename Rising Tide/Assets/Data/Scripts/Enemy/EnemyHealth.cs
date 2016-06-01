using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float enemyHealthMax;
	private float enemyHealthCurr;
	public float PlayerHealthRestoreValue;
	private string ecosystem;
	public int prevMod = 0;
	[Range(1, 500)]
	public int hitSoundCounter = 1;
	public AudioSource hitSound;

	// Use this for initialization
	void Start () {
		setDiffStats ();
		ecosystem = GetComponent<BasicEnemy> ().ecosystem;
		enemyHealthCurr = enemyHealthMax;
	}




	private void setDiffStats(){
		switch (gameObject.GetComponent<BasicEnemy> ().fishType) {
		case "barracuda":
			enemyHealthMax = 50;
			PlayerHealthRestoreValue = 20;
			break;
		case "tuna":
			enemyHealthMax = 25;
			PlayerHealthRestoreValue = 10;
			break;

		
		case "swordfish":
			enemyHealthMax = 75;
			PlayerHealthRestoreValue = 40;
			break;
		

		case "angler":
			enemyHealthMax = 45;
			PlayerHealthRestoreValue = 18;
			break;


		case "whale":
			enemyHealthMax = 200;
			PlayerHealthRestoreValue = 9000;
			break;
		case "manta":
			enemyHealthMax = 65;
			PlayerHealthRestoreValue= 15;
			break;
		case "flounder":
			enemyHealthMax = 35;
			PlayerHealthRestoreValue= 13;
			break;
		case "shark":
			enemyHealthMax = 100;
			PlayerHealthRestoreValue = 60;
			break;
		}

	}



	// Update is called once per frame
	void Update () {
		if (enemyHealthCurr <= 0) {
			GameObject.Find (ecosystem).GetComponent<EcoPoints> ().Die (gameObject);
		} else if (  (  ( (enemyHealthMax - enemyHealthCurr) %  (hitSoundCounter)) == 0) &&   ( (enemyHealthMax - enemyHealthCurr) /  (hitSoundCounter))  > prevMod )  {
			prevMod =  (int)( (enemyHealthMax - enemyHealthCurr) /  (hitSoundCounter));
			if (hitSound && !hitSound.isPlaying)
				hitSound.Play ();
		}
	}

	public float getHealthCurr(){
		return enemyHealthCurr;
	}
	public void resetHealth(){
		enemyHealthCurr = enemyHealthMax;

	}

	public bool enemyTakeDmg(float dmgReceivedVal){
		enemyHealthCurr -= dmgReceivedVal;
		return enemyHealthCurr <= 0;
	}
}
