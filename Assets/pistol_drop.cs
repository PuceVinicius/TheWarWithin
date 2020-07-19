using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol_drop : MonoBehaviour
{

    public GameObject pistol;

    void OnTriggerEnter(Collider other) {  
        Debug.Log("Pistol trigger box");
        pistol.GetComponent<Rigidbody>().useGravity = true;
        Destroy(gameObject);
    }  
}
