using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Player_stats : MonoBehaviour {
	
	public float PlayerHealthMax = 10f;
	public float PlayerOverhealthMax;
	public float PlayerCurrHealth;
    public float restartDelay = 5f;
	public bool PlayerDmged;
	public float PlayerDmgOutput;
	private Color lowAlph;
	private Color normalAlph;

    //private Animator anim;
    //float restartTimer;

    /*void Awake()
    {
        anim = GetComponent<Animator>();
    }*/

    // Use this for initialization
    void Start () {
		PlayerCurrHealth = PlayerHealthMax;
		normalAlph = GetComponent<Renderer>().material.color;
		lowAlph = GetComponent<Renderer>().material.color;
		lowAlph.a = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
	
	/*if (PlayerCurrHealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
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
            }
        }*/
	
	}


    public void playerDamage(float val)
	{
		PlayerDmged = true;
		PlayerCurrHealth -= val;
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
