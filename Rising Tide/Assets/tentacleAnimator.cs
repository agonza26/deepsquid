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

        if (Input.GetMouseButtonDown(0))
        {
            if (!anim.GetBool("grabbing"))
            { //start grabbing
                anim.SetBool("grabbing", true);
            }
            else if (anim.GetBool("grabbing"))
            { //stop grabbing
                anim.SetBool("grabbing", false);
            }
            Debug.Log("Now grabbing");
            //anim.SetBool("isSwimming", false);
        }

        if (Input.GetMouseButtonDown(1)) //0 left click, 1 right click, 2 middlle click
        {
            if (!anim.GetBool("swimming"))
            {  //start swimming
                anim.SetBool("swimming", true);
            }
            else if (anim.GetBool("swimming"))
            { //stop swimming
                anim.SetBool("swimming", false);
            }

        }

    }

}
