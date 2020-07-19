using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign_activate : MonoBehaviour
{
    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;
    public GameObject sign4;
    public GameObject sign5;
    public GameObject sign6;

    void OnTriggerEnter(Collider other) {  
        Debug.Log("Sign triggered");
        sign1.SetActive(true);
        sign2.SetActive(true);
        sign3.SetActive(true);
        sign4.SetActive(true);
        sign5.SetActive(false);
        sign6.SetActive(false);
    }  
}
