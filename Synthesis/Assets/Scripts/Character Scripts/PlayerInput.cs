using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CharacterController3D controller;
    public CharacterCombat Combat; 
    public float runSpeed = 40f;

    float LRMove = 0f;
    private bool crouch = false, jump = false,DoubleJump=false,CanDoubleJump=false;
    // Update is called once per frame
    void Update()
    {
        //LR move
        LRMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //for input manager later on, but for now, i have the big stupid 
        // if (Input.GetButtonDown("Jump"))
        // {
        //     jump = true;
        // }
      //  if (Input.GetKeyUp("space"))
      //  {
      //      CanDoubleJump = true;
      //  }

        //Jump
        if (Input.GetKeyDown("space"))
        {

            if (controller.GetIfGrounded() == false && CanDoubleJump == true)
            {
                DoubleJump = true;
                CanDoubleJump = false;
            }
            else if (controller.GetIfGrounded()==true)
            {
                CanDoubleJump = true;
                jump = true;
            }
        }

        //Attack1 
        if (Input.GetKeyDown("1"))
        {
            Combat.Attack(controller.transform,1);
        }
        //Attack2 
        if (Input.GetKeyDown("2"))
        {
            Combat.Attack(controller.transform, 2);
        }
        //Attack3 
        if (Input.GetKeyDown("3"))
        {
            Combat.Attack(controller.transform, 3);
        }
      //devhacks 
        if (Input.GetKeyDown("p"))
        {
            if (GetComponent<HealthSystem>().GetHealthLimit()> GetComponent<HealthSystem>().GetHealth())
            GetComponent<HealthSystem>().HealthUp(1);
        }
        Debug.Log("jump" + jump);
        // if (Input.GetButtonDown("Crouch"))
        // {
        //     crouch = true;
        // }
        // else if (Input.GetButtonUp("Crouch"))
        // {
        //     crouch = false;
        // }
        // {
        //     crouch = true;
        // }
    }
    public void SetJump(bool jump)
    {
        CanDoubleJump = jump;
    }
    private void FixedUpdate()
    {
        controller.Move(LRMove * Time.fixedDeltaTime, crouch, jump,DoubleJump);
        jump = false;
        DoubleJump = false;
    }
}
