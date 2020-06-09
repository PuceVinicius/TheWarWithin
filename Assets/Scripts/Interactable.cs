using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 4f;
	Transform player;

	void update() {
		float distance = Vector3.Distance(player.position, transform.position);
		if (distance <= radius) {
			Debug.Log("IN RANGE");
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
