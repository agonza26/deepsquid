using UnityEngine;
using System.Collections;

public class inkGateObject : MonoBehaviour {

    bool isActive;

	public GameObject MuralA;
	public GameObject MuralB;
	public GameObject MuralC;
	bool Acomp;
	bool Bcomp;
	bool Ccomp;
    public Transform target;
    public Transform defaultPos;
    public float speed;

    //public GameObject inkObject;

    // Use this for initialization
    void Start()
    {
        //inkObject = GameObject.Find("InkMural");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inkObject.GetComponent<inkObjectPuzzle>().activated);
		Acomp = MuralA.GetComponent<inkObjectPuzzle>().activated && MuralA.GetComponent<inkObjectPuzzle>().hasAnOrb;
		Bcomp = MuralB.GetComponent<inkObjectPuzzle>().activated && MuralB.GetComponent<inkObjectPuzzle>().hasAnOrb;
		Ccomp = MuralC.GetComponent<inkObjectPuzzle>().activated && MuralC.GetComponent<inkObjectPuzzle>().hasAnOrb;
		if(Acomp && Bcomp && Ccomp)
		{
			isActive = true;
		}
        if (isActive)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        /*else 
        {
			
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, defaultPos.position, step);
        }*/
    }

}
