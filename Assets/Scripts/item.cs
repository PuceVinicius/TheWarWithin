using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	public enum ItemType {
		ChocolateBar,
		Steak,
		Apple,
		Peach,
		WaterBootle,
		Soda,
		Soup,
		Medkit,
	}

	public ItemType item_type;
	public int amount;
}
