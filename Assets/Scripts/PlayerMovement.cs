using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;

    public bool movementOverride = false;

    public bool overrideDirectionLeft = false;

    // Update is called once per frame
    void Update()
    {
        if (movementOverride && overrideDirectionLeft)
        {
            horizontalMove = -120;
        }
        else if(movementOverride && !overrideDirectionLeft)
        {
            horizontalMove = 120;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        if (Time.timeScale == 1)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

    }


    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, false);
    }

}
