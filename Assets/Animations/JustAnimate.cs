using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustAnimate : MonoBehaviour
{
    Animator PlayerAnimator;
    float HorizontalMovement;
    float VerticalMovement;
    float RunningMovement;
    float JumpMovement;

    bool ground;

    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        ground = GetComponent<player_movement>().is_grounded;
        //Translate the left and right button presses or the horizontal joystick movements to a float
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        RunningMovement = Input.GetAxis("Fire3");
        JumpMovement = Input.GetAxis("Jump");
        //Sends the value from the horizontal axis input to the animator. Change the settings in the
        //Animator to define when the character is walking or running
        PlayerAnimator.SetBool("Jump", JumpMovement != 0);
        PlayerAnimator.SetBool("Walk", (HorizontalMovement != 0 || VerticalMovement != 0) && ground);
        PlayerAnimator.SetBool("Run", RunningMovement != 0 && ground);
    }
}
