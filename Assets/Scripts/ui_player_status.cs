using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_player_status : MonoBehaviour
{

	public Text ui_status;
	public GameObject p;
	public float text_update_delay;

    player_status player;

	private float delay;
    
    void Start()
    {
    	player = p.GetComponent<player_status>();
		delay = 0;
    }

    // Update is called once per frame
    void Update() {
		
		delay += Time.deltaTime;

		if(delay >= text_update_delay) {
			delay -= text_update_delay;

			if (player.debug_mode) {

				ui_status.text = "";
				ui_status.text += "EMOTIONS\n";
				ui_status.text += "joy: " + player.joy + "\n";
				ui_status.text += "fear: " + player.fear + "\n";
				ui_status.text += "anger: " + player.anger + "\n";
				ui_status.text += "sadness: " + player.sadness + "\n";
				ui_status.text += "disgust: " + player.disgust + "\n\n";

				ui_status.text += "NEEDS\n";
				ui_status.text += "food: " + player.food + "\n";
				ui_status.text += "water: " + player.water + "\n";
				ui_status.text += "bathroom: " + player.bathroom + "\n";
				ui_status.text += "sleep: " + player.sleep + "\n";
				ui_status.text += "fatigue: " + player.fatigue + "\n\n";

				ui_status.text += "HP: " + player.hp + "\n";
			}
			else {
				ui_status.text = "";	    	
			}
		}
    }
}
