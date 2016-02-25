using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tentacleAnimator : MonoBehaviour
{

    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //if moving forward (pressing W), play swimming animation, stop when key released
        bool isSwimming = Input.GetKey("w");
        anim.SetBool("swimming", isSwimming);

        //press grab/throw button or left click to start grab animation, press again to exit grab animation
        if (GetComponentInParent<PickupObject>().carrying)//Input.GetMouseButtonDown(0))//Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q) ||) 
        {
            //if (!anim.GetBool("grabbing"))
            //{ //start grabbing
                anim.SetBool("grabbing", true);
            //}
            //else if (anim.GetBool("grabbing"))
            //{ //stop grabbing
            //}
            //Debug.Log("Now grabbing");
        }
		else
		{
			anim.SetBool("grabbing", false);
			//Debug.Log("Releasing held object");
		}

        //right click to start swim animation, and again to exit swim animation
        if (GetComponentInParent<simple_movement>().acc > 0)//Input.GetMouseButtonDown(1)) //0 left click, 1 right click, 2 middlle click
        {
            //if (!anim.GetBool("swimming"))
            //{  //start swimming
                anim.SetBool("swimming", true);
            //}
            //else if (anim.GetBool("swimming"))
            //{ //stop swimming
                
            //}

        }
		else if(GetComponentInParent<simple_movement>().acc <= 0)
		{
			anim.SetBool("swimming", false);
		}

    }

}
