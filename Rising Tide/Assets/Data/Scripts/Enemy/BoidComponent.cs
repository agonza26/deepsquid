using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidComponent : MonoBehaviour {
	[Range(1f, 10f)]
	public float rSM = 3f; // randomSpeedMult

	public float vlim;


	private float m1,m2,m3,m4;
	private Vector3 boidVelocity;



	private bool isInit = false;
	private bool shouldFlock = true;


	public void init(float a1,float a2,float a3,float a4,float vl){
		vlim = vl;
		isInit = true;
		m1 = a1;
		m2 = a2;
		m3 = a3;
		m4 = a4;
		//boidVelocity = new Vector3 (Random.Range (-rSM, rSM), Random.Range (-rSM, rSM), Random.Range (-rSM, rSM));
		boidVelocity = new Vector3 (0,0,0);
	}







	// Use this for initialization
	//void Start () {

	//}

	// Update is called once per frame
	//void Update () {

	//}






	public void run(GameObject self, List<GameObject> l, GameObject chasee){
		Vector3 r1 = rule1(self, l);
		Vector3 r2 = rule2(self, l);
		Vector3 r3 = rule3(self, l);
		Vector3 r4 = rule4(self, l, chasee);

		boidVelocity += m1 * r1 + m2*r2 + m3*r3 + m4 * r4 ;

		//boidVelocity += m4 * (r4);

		transform.position += limitVel(boidVelocity);
		//GetComponent<Rigidbody>().velocity = limitVel(boidVelocity);

	}






	//go towards center
	private Vector3 rule1(GameObject self, List<GameObject> l)
	{
		//
		Vector3 pcJ = new Vector3(0,0,0);

		GameObject[] temp = l.ToArray ();
		for (int i = 0; i < l.Count; i++) {
			if (temp[i] == self) {

			} else {
				pcJ = pcJ + temp[i].transform.position;
			}

		}

		pcJ = pcJ / (l.Count - 1);

		return (pcJ - self.transform.position);
	}







	//obstacle avoidance within group
	private Vector3 rule2(GameObject self, List<GameObject> l)
	{
		Vector3 c = new Vector3(0,0,0);

		GameObject[] temp = l.ToArray ();
		for (int i = 0; i < l.Count; i++) {
			if (temp[i] == self) {

			} else {
				if (Vector3.Distance (self.transform.position, temp[i].transform.position) < 100) {
					c = c - (self.transform.position - temp [i].transform.position);
				}

			}
		}
			
		return c;
	}







	//match velocity of group

	private Vector3 rule3(GameObject self, List<GameObject> l)
	{

		Vector3 pvJ = new Vector3 (0, 0, 0);


		GameObject[] temp = l.ToArray ();
		for (int i = 0; i < l.Count; i++) {
			if (temp[i] == self) {
			} else {
				pvJ = pvJ + temp [i].GetComponent<BoidComponent>().boidVelocity;

			}
		}

		pvJ = pvJ / (l.Count-1);

		return  (pvJ - boidVelocity);
	}



	//follow chasee
	private Vector3 rule4(GameObject self, List<GameObject> l, GameObject chasee)
	{
		return chasee.transform.position-self.transform.position;
	}



	private Vector3 limitVel(Vector3 currVel){
		Debug.Log(Vector3.ClampMagnitude(currVel, vlim));
		return Vector3.ClampMagnitude(currVel, vlim);
	}











	string toggleFlock(){
		if (shouldFlock) {
			shouldFlock = false;
			return "notFlocking";
		}
		shouldFlock = true;
		return "isFlocking";
	}




	public bool changeMult(string key, float value){
		bool status = true;
		switch (key) {
		case "1":
		case "m1":
			m1 = value;
			break;
		case "2":
		case "m2":
			m2 = value;
			break;
		case "3":
		case "m3":
			m3 = value;
			break;
		case "4":
		case "m4":
			m4 = value;
			break;
		default:
			status = false;
			break;
		}
		return status;
	}
}