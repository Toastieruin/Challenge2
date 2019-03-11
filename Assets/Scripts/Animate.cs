using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))

                anim.SetInteger("State", 1);

        }
        {

            if (Input.GetKeyUp(KeyCode.RightArrow))

                anim.SetInteger("State", 0);

        }
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))

                anim.SetInteger("State", 1);

        }
        {

            if (Input.GetKeyUp(KeyCode.LeftArrow))

                anim.SetInteger("State", 0);

        }
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))

                anim.SetInteger("State", 2);

        }
        {

            if (Input.GetKeyUp(KeyCode.UpArrow))

                anim.SetInteger("State", 0);

        }
    }
}
