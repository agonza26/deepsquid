using UnityEngine;
using System.Collections;

public class inkGateObject : MonoBehaviour {

    bool isActive;

    public Transform target;
    public Transform defaultPos;
    public float speed;

    public GameObject inkObject;

    // Use this for initialization
    void Start()
    {
        //inkObject = GameObject.Find("InkMural");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inkObject.GetComponent<inkObjectPuzzle>().activated);
        isActive = inkObject.GetComponent<inkObjectPuzzle>().activated;

        if (isActive)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else 
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, defaultPos.position, step);
        }
    }
}
