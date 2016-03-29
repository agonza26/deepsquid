using UnityEngine;

public class BE_Stats : MonoBehaviour
{
    public int startingHealth = 2;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.

    bool isSinking = false;                             // Whether the enemy has started sinking through the floor.


    void Awake()
    {
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            StartSinking();
        }

        // If the enemy should be sinking...
        if (isSinking == true)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    void OnCollisionEnter(Collision o)
    {
        if (o.gameObject.tag == "Player")
        {
            currentHealth -= 1;
        }
        else
        {
            return;
        }
    }


    public void StartSinking()
    {
        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }
}