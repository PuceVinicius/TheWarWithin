using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class player_status : MonoBehaviour
{

	public bool debug_mode = false;
    public GameObject Inventory;

	// ###########################################################
	// 							Emotions
	// ###########################################################

	public float joy = 60f;
	public float fear = 60f;
	public float anger = 60f;
	public float sadness = 60f;
	public float disgust = 60f;

	public float joy_min = 70f;
	public float joy_max = 90f;
	public float fear_min = 70f;
	public float fear_max = 90f;
	public float anger_min = 70f;
	public float anger_max = 90f;
	public float sadness_min = 70f;
	public float sadness_max = 90f;
	public float disgust_min = 70f;
	public float disgust_max = 90f;

	// ###########################################################
	// 							Needs
	// ###########################################################

	public float food = 100f;
	public float water = 100f;
	public float bathroom = 100f;
	public float sleep = 100f;
	public float fatigue = 100f;

	public float food_min = 100f;
	public float food_max = 100f;
	public float water_min = 100f;
	public float water_max = 100f;
	public float bathroom_min = 100f;
	public float bathroom_max = 100f;
	public float sleep_min = 100f;
	public float sleep_max = 100f;
	public float fatigue_min = 100f;
	public float fatigue_max = 100f;

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

	private global_shader global_shader;
	Color white = new Color(1f,1f,1f);
	Color gray = new Color(0.5f,0.5f,0.5f);
	Color base1 = new Color(0,0,0);

	public float ratioQ = 0.75f;

	float tempo;

    float JoyQ;
    float FearQ;
    float AngerQ;
    float SadnessQ;
    float DisgustQ;
    float BathroomQ;
    float SleepQ;
    float FatigueQ;

    // Start is called before the first frame update
    void Start() {
		global_shader = GetComponent<global_shader>();
		Inventory.SetActive(is_inventory_open);
	}

    // Update is called once per frame
    void Update() {

		if (fatigue >= 95f) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
		}

		UpdateGlobalShader();

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
		UpdateQueue();
		//DecreasePerTime();
    }

	void DecreasePerTime() {

		joy += joy_dec_rate * Time.deltaTime;
		fear += fear_dec_rate * Time.deltaTime;
		anger += anger_dec_rate * Time.deltaTime;
		sadness += sadness_dec_rate * Time.deltaTime;
		disgust += disgust_dec_rate * Time.deltaTime;

		food -= food_dec_rate * Time.deltaTime;
		water -= water_dec_rate * Time.deltaTime;
		bathroom += bathroom_dec_rate * Time.deltaTime;
		sleep += sleep_dec_rate * Time.deltaTime;
		fatigue += fatigue_dec_rate * Time.deltaTime;

		hp -= hp_dec_rate * Time.deltaTime;
	}

	public void joyQueue(float value) {JoyQ += value;}
	public void fearQueue(float value) {FearQ += value;}
	public void angerQueue(float value) {AngerQ += value;}
	public void sadnessQueue(float value) {SadnessQ += value;}
	public void disgustQueue(float value) {DisgustQ += value;}
	public void bathroomQueue(float value) {BathroomQ += value;}
	public void sleepQueue(float value) {SleepQ += value;}
	public void fatigueQueue(float value) {FatigueQ += value;}

	void UpdateQueue() {
		tempo = ratioQ * Time.deltaTime;
		if (Mathf.Abs(JoyQ) >= ratioQ) {
			if (JoyQ > 0) {
				joy += tempo;
				JoyQ -= tempo;
			}
			else {
				joy -= tempo;
				JoyQ += tempo;
			}
		}
		if (Mathf.Abs(FearQ) >= ratioQ) {
			if (FearQ > 0) {
				fear += tempo;
				FearQ -= tempo;
			}
			else {
				fear -= tempo;
				FearQ += tempo;
			}
		}
		if (Mathf.Abs(AngerQ) >= ratioQ) {
			if (AngerQ > 0) {
				anger += tempo;
				AngerQ -= tempo;
			}
			else {
				anger -= tempo;
				AngerQ += tempo;
			}
		}
		if (Mathf.Abs(SadnessQ) >= ratioQ) {
			if (SadnessQ > 0) {
				sadness += tempo;
				SadnessQ -= tempo;
			}
			else {
				sadness -= tempo;
				SadnessQ += tempo;
			}
		}
		if (Mathf.Abs(DisgustQ) >= ratioQ) {
			if (DisgustQ > 0) {
				disgust += tempo;
				DisgustQ -= tempo;
			}
			else {
				disgust -= tempo;
				DisgustQ += tempo;
			}
		}
		if (Mathf.Abs(BathroomQ) >= ratioQ) {
			if (BathroomQ > 0) {
				bathroom += tempo;
				BathroomQ -= tempo;
			}
			else {
				bathroom -= tempo;
				BathroomQ += tempo;
			}
		}
		if (Mathf.Abs(SleepQ) >= ratioQ) {
			if (SleepQ > 0) {
				sleep += tempo;
				SleepQ -= tempo;
			}
			else {
				sleep -= tempo;
				SleepQ += tempo;
			}
		}
		if (Mathf.Abs(FatigueQ) >= ratioQ) {
			if (FatigueQ > 0) {
				fatigue += tempo;
				FatigueQ -= tempo;
			}
			else {
				fatigue -= tempo;
				FatigueQ += tempo;
			}
		}
	}

	void UpdateGlobalShader () {
		UpdateEmotions();
		UpdateNeeds();
	}

	void UpdateEmotions() {
		UpdateJoy();
		UpdateAnger();
		UpdateSadness();
		UpdateFear();
		UpdateDisgust();
	}

	void UpdateNeeds() {
		UpdateBathroom();
		UpdateSleep();
		UpdateFatigue();
	}

	void UpdateJoy() {
		if (joy >= joy_min) {
			float joyBase = Mathf.Clamp(joy, joy_min, joy_max);

			float saturation = EmotionToValue(joyBase, joy_min, joy_max, 0f, 100f);
			global_shader.UpdateColorAdjustment(0f, 0f, white, 0f, saturation, false);
		
			float bng = EmotionToValue(joyBase, joy_min, joy_max, 0.5f, 1f);
			base1 = new Color(bng, bng, bng);
			global_shader.UpdateSplitToning(gray, base1, false, true);
		}
	}

	void UpdateFear() {
		if (fear >= fear_min) {
			float fearBase = Mathf.Clamp(fear, fear_min, fear_max);

			float contrast = EmotionToValue(fearBase, fear_min, fear_max, 0f, 100f);
			global_shader.UpdateColorAdjustment(0f, contrast, white, 0f, 0f, false);
		
			float intensity = EmotionToValue(fearBase, fear_min, fear_max, 0f, 30f);
			global_shader.UpdateMotionBlur(intensity);
		}
	}

	void UpdateAnger() {
		if (anger >= anger_min) {
			float angerBase = Mathf.Clamp(anger, anger_min, anger_max);

			float smooth = EmotionToValue(angerBase, anger_min, anger_max, 0.2f, 0.8f);
			float round = EmotionToValue(angerBase, anger_min, anger_max, 0.5f, 1f);
			global_shader.UpdateVignette(white, smooth, round, true, false);

			float dist = EmotionToValue(angerBase, anger_min, anger_max, 100f, 13f);
			global_shader.UpdateDepthOfField(DepthOfFieldMode.Manual, dist, dist*2);

			float contrast = EmotionToValue(angerBase, anger_min, anger_max, 0f, 70f);
			float bng = EmotionToValue(angerBase, anger_min, anger_max, 1f, 0.72f);
			base1 = new Color(1f,bng,bng);
			global_shader.UpdateColorAdjustment(0f, contrast, base1, 0f, 10f, true);
		}
	}

	void UpdateSadness() {
		if (sadness >= sadness_min) {
			float sadnessBase = Mathf.Clamp(sadness, sadness_min, sadness_max);

			float saturation = EmotionToValue(sadnessBase, sadness_min, sadness_max, 0f, -80f);
			global_shader.UpdateColorAdjustment(0f, 0f, white, 0f, saturation, false);
		
			float bng = EmotionToValue(sadnessBase, sadness_min, sadness_max, 0.5f, 0f);
			base1 = new Color(bng, bng, bng);
			global_shader.UpdateSplitToning(base1, gray, true, false);
		}
	}

	void UpdateDisgust() {
		if (disgust >= disgust_min) {
			float disgustBase = Mathf.Clamp(disgust, disgust_min, disgust_max);

			float bng = EmotionToValue(disgustBase, disgust_min, disgust_max, 1f, 0.75f);
			base1 = new Color(bng, 1f, bng);
			global_shader.UpdateColorAdjustment(0f, 0f, base1, 0f, 0f, true);
		
			float intensity = EmotionToValue(disgustBase, disgust_min, disgust_max, 0f, -0.6f);
			global_shader.UpdateLensDistortion(intensity);
		}
	}

	void UpdateBathroom() {
		if (bathroom >= bathroom_min) {
			float bathroomBase = Mathf.Clamp(bathroom, bathroom_min, bathroom_max);

			float distance = EmotionToValue(bathroomBase, bathroom_min, bathroom_max, 0f, 1f);
			global_shader.UpdatePaniniProjection(distance);
		}
	}

	void UpdateSleep() {
		if (sleep >= sleep_min) {
			float sleepBase = Mathf.Clamp(sleep, sleep_min, sleep_max);

			float intensity = EmotionToValue(sleepBase, sleep_min, sleep_max, 0f, 1f);
			global_shader.UpdateBloom(intensity);
		}
	}

	void UpdateFatigue() {
		if (fatigue >= fatigue_min) {
			float fatigueBase = Mathf.Clamp(fatigue, fatigue_min, fatigue_max);

			float intensity = EmotionToValue(fatigueBase, fatigue_min, fatigue_max, 0f, 1f);
			global_shader.UpdateFilmGrain(intensity);
		}
	}

	float EmotionToValue(float value, float min1, float max1, float min2, float max2) {
		return ((max2 - min2) / (max1 - min1)) * (value - min1) + min2;
	}
}
