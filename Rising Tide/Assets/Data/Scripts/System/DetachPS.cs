using UnityEngine;
using System.Collections;

public class DetachPS : MonoBehaviour {

	public float destroyPSafter = 2.5f;
	float timePassed = 0;
 // blah blah rest of code
 // Call this immediately before you destroy your missile
	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > destroyPSafter) 
		{
			Destroy (gameObject);
		}
	}
 public void DetachParticles()
 {
     // This splits the particle off so it doesn't get deleted with the parent
     transform.parent = null;
 
     // this stops the particle from creating more bits
		GetComponent<ParticleSystem>().emissionRate = 0;
 
     // This finds the particleAnimator associated with the emitter and then
     // sets it to automatically delete itself when it runs out of particles
		//Destroy(gameObject);
 }



}
	
