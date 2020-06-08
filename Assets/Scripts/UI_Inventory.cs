using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{

	private Inventory inventory;
	private Transform item_slot_container;
	private Transform item_slot_template;

	private void Awake() {
		item_slot_container = transform.Find("itemSlotContainer");
		item_slot_template = item_slot_container.Find("itemSlotTemplate")
	}

	public void set_inventory(Inventory inventory) {
		this.inventory = inventory;
	}
}
