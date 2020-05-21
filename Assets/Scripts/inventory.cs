using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	private List<Item> item_list;

	public Inventory() {
		item_list = new List<Item>();

		AddItem(new Item {item_type = Item.ItemType.Apple, amount = 1});
		Debug.Log(item_list.Count);
	}

	public void AddItem(Item item){
		item_list.Add(item);
	}

}
