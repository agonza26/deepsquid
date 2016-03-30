using UnityEngine;
using System.Collections;

public class inkGateObject : MonoBehaviour {

    bool isActive;

	public GameObject MuralA;
	public GameObject MuralB;
	public GameObject MuralC;
	public GameObject MuralD;
	bool Acomp;
	bool Bcomp;
	bool Ccomp;
	bool Dcomp;
    public Transform target;
    public Transform defaultPos;
    public float speed;
	public float playPartFor;
	float count;

	public ParticleSystem g1;
	public ParticleSystem g2;
	public ParticleSystem g3;
	public ParticleSystem g4;
	public ParticleSystem g5;
	public ParticleSystem g6;
	public ParticleSystem g7;

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
		Dcomp = MuralD.GetComponent<inkObjectPuzzle>().activated && MuralD.GetComponent<inkObjectPuzzle>().hasAnOrb;
		if(Acomp && Bcomp && Ccomp && Dcomp)
		{
			isActive = true;
			if (count < playPartFor) 
			{
				g1.Emit(15);
				g2.Emit(15);
				g3.Emit(15);
				g4.Emit(15);
				g5.Emit(15);
				g6.Emit(15);
				g7.Emit (15);
				count++;
			}

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
