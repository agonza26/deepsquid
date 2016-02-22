using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private GameObject deathManager;
    //public float playerHealth;  // Reference to the player's health.
    //public float currHealth;
    public float restartDelay = 5f;         // Time to wait before restarting the level


    //Animator anim;                          // Reference to the animator component.
    float restartTimer = 0;                     // Timer to count up to restarting the level


    void Awake()
    {
        // Set up the reference.
        //anim = GetComponent<Animator>();

    }

    void Start()
    {
       // anim = GetComponent<Animator>();
        deathManager = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // If the player has run out of health...
        if (deathManager.GetComponent<Player_stats>().PlayerCurrHealth <= 0)
        {
            //anim.SetTrigger("GameOver");
            //StartCoroutine(respawn());
            deathManager.GetComponent<simple_movement>().toggleDeathState(); //movement is toggled off
			deathManager.GetComponent<Abilities>().toggleDeathState(); //abilities are toggled off
              //currHealth = 1;
              restartTimer = Time.deltaTime;
              //anim.SetTrigger("GameOver");
              if (restartDelay >= restartTimer + Time.deltaTime)
              {
                  //restartTimer = Time.time;
                  SceneManager.LoadScene("DeathScene");
            }
        }
    }

    IEnumerator respawn()
    {
        //currHealth = deathManager.GetComponent<Player_stats>().PlayerCurrHealth;
       
        
        yield return StartCoroutine(WaitThisLong(6.1f));
        SceneManager.LoadScene("Backup");
        
    }

    IEnumerator WaitThisLong(float x)
    {
        yield return new WaitForSeconds(x);
    }
}