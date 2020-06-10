﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

	public CharacterController controller;

	public float speed = 12f;
	public float gravity = -9.81f;
	public float jump_height = 3f;

	public Transform ground_check;
	public float ground_distance = 0.4f;
	public LayerMask ground_mask;

	Vector3 velocity;
	bool is_grounded;
    public player_status player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

        if (is_grounded && velocity.y < 0) {
        	velocity.y = -2f;
        }

        if(!player.is_inventory_open) {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && is_grounded) {
        	velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
