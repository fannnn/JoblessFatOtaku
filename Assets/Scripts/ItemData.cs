using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemData : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start(){
		items.Add (new Item ("this is it", 3, "how it work", 99, 99, Item.ItemType.Weapon));
	}

}
