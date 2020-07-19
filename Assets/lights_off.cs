using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights_off : MonoBehaviour
{
    
    public GameObject light;
    public GameObject post1;
    public GameObject post2;
    public GameObject post3;
    public GameObject post4;
    public GameObject box;

    void OnTriggerEnter(Collider other) {  
        Debug.Log("LIGHTS OFF");
        light.SetActive(false);
        post1.SetActive(true);
        post2.SetActive(true);
        post3.SetActive(true);
        post4.SetActive(true);
        box.SetActive(true);
    }
}
