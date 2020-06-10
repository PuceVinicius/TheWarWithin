using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player_status : MonoBehaviour
{

	public bool debug_mode = false;
    public GameObject Inventory;

	// ###########################################################
	// 							Emotions
	// ###########################################################

	public float joy = 100f;
	public float fear = 100f;
	public float anger = 100f;
	public float sadness = 100f;
	public float disgust = 100f;

	// ###########################################################
	// 							Needs
	// ###########################################################

	public float food = 100f;
	public float water = 100f;
	public float bathroom = 100f;
	public float sleep = 100f;
	public float fatigue = 100f;

	public float hp = 100f;

	// ###########################################################
	// 						Decrease Rate
	// ###########################################################

	public float joy_dec_rate = 1f;
	public float fear_dec_rate = 1f;
	public float anger_dec_rate = 1f;
	public float sadness_dec_rate = 1f;
	public float disgust_dec_rate = 1f;

	public float food_dec_rate = 1f;
	public float water_dec_rate = 1f;
	public float bathroom_dec_rate = 1f;
	public float sleep_dec_rate = 1f;
	public float fatigue_dec_rate = 1f;

	public float hp_dec_rate = 1f;

	// ###########################################################
	// 						    Inventory
	// ###########################################################

	public bool is_inventory_open = false;

    // Start is called before the first frame update
    void Start() {
		Inventory.SetActive(is_inventory_open);
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Debug Activation")) {
        	debug_mode = !debug_mode;
        }

		if (Input.GetButtonDown("Inventory")) {
			Inventory.SetActive(!Inventory.activeSelf);
			if (Inventory.activeSelf) {
				Cursor.lockState = CursorLockMode.Confined;
				is_inventory_open = true;
				Cursor.visible = true;
			}
			else {
				is_inventory_open = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		joy -= joy_dec_rate * Time.deltaTime;
		fear -= fear_dec_rate * Time.deltaTime;
		anger -= anger_dec_rate * Time.deltaTime;
		sadness -= sadness_dec_rate * Time.deltaTime;
		disgust -= disgust_dec_rate * Time.deltaTime;

		food -= food_dec_rate * Time.deltaTime;
		water -= water_dec_rate * Time.deltaTime;
		bathroom -= bathroom_dec_rate * Time.deltaTime;
		sleep -= sleep_dec_rate * Time.deltaTime;
		fatigue -= fatigue_dec_rate * Time.deltaTime;

		hp -= hp_dec_rate * Time.deltaTime;
    }
}
