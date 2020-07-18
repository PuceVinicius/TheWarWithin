using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{

	public float mouse_sensitivity_x = 100f;
	public float mouse_sensitivity_y = 100f;

	public GameObject player_body;

	float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_body.GetComponent<player_status>().is_inventory_open) {
            float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity_x * Time.deltaTime;
            float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity_y * Time.deltaTime;
        
            xRotation -= mouse_y;
            xRotation = Mathf.Clamp(xRotation, -90f, 50f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player_body.GetComponent<Transform>().Rotate(Vector3.up * mouse_x);
        }
    }
}
