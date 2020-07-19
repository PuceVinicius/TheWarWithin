using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_light : MonoBehaviour
{
    public GameObject light_box;
    public GameObject light_box2;
    
    void OnTriggerEnter(Collider other) {  
        Debug.Log("trigger light box");
        light_box.SetActive(true);
        light_box2.SetActive(true);
    }  

}
