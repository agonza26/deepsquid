using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player_stats : MonoBehaviour {
	
	public float PlayerHealthMax = 10f;
	public float PlayerOverhealthMax;

	public float PlayerCurrHealth;
    public float restartDelay = 5f;
	public bool PlayerDmged;
	public float PlayerDmgOutput = 30f;
	public Image healthBar;
	private Color lowAlph;
	private Color normalAlph;


    // Use this for initialization
    void Start () {
		PlayerCurrHealth = PlayerHealthMax;
		normalAlph = GetComponent<Renderer>().material.color;
		lowAlph = GetComponent<Renderer>().material.color;
		lowAlph.a = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = PlayerCurrHealth / PlayerHealthMax;
	
		if (PlayerCurrHealth <= 0) {
			GetComponent<improved_movement> ().toggleDeathState ();

			/*if (gameObject.CompareTag("Player"))
		            {
		                Destroy(gameObject);
		                Debug.Log("player dead");
		                SceneManager.LoadScene("Backup");
		            }
		            anim.SetTrigger("GameOver");
		            restartTimer += Time.deltaTime;

		            if(restartTimer >= restartDelay)
		            {
		                SceneManager.LoadScene("Backup");
		            }*/
		} else {
			if(Input.GetKeyUp("x"))
			{
				playerDamage(1f);
			}
		}
			
			


	}


	void OnCollisionEnter(Collision other) {
		GameObject item = other.gameObject;



		if (item.tag == "Enemy") {
			BasicEnemy be = item.GetComponent<BasicEnemy> ();
			if (be.state != "patrol") {
				playerDamage (1f);

				be.state = "recharge";
				be.stunMult = 1f;

			}
		}

	}


    public void playerDamage(float val)
	{
		PlayerDmged = true;
		PlayerCurrHealth -= val;
		if (PlayerCurrHealth > PlayerHealthMax)
			PlayerCurrHealth = PlayerHealthMax;
	}

    public void changePlayerAlphaDown()
	{
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, lowAlph, 5f * Time.deltaTime);		
	}
	
	public void changePlayerAlphaUp()
	{
		if(GetComponent<Renderer>().material.color.a > normalAlph.a)
		{
			return;
		}
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, normalAlph, 5f * Time.deltaTime); 
	}
	
	public float giveDmg()
	{
		return PlayerDmgOutput;
	}
}
