using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;

	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();

	private ItemData itemData; 


	// Use this for initialization
	void Start () {
		for(int i = 0;i<(slotsX*slotsY);i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		itemData = GameObject.FindWithTag ("ItemData").GetComponent<ItemData> ();
		AddItem (0);
		AddItem (1);
		AddItem (3);
		print(InventoryCheck (0));
		print(InventoryCheck (1));
		print(InventoryCheck (5));
		RemoveItem (0);


	}
	void OnGUI(){
		int i = 0;

		for (int y =0; y < slotsY; y++) {
			for (int x =0; x < slotsX; x++) {
				Rect slotRect = new Rect(x*80,y*80,70,70);
				GUI.Box(slotRect,"");
				slots[i]= inventory[i];
				if(slots[i].itemName != null){
					GUI.Box(new Rect(x*80,y*80,60,60),inventory[i].itemName);
					if(slotRect.Contains(Event.current.mousePosition)){
						GUI.Box(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,100,100),"this is"+inventory[i].itemName);
					}
				}
				i++;
			}
		}
	}
	void AddItem(int id){
		for (int i= 0; i <inventory.Count; i++) {
			if(inventory[i].itemName == null){
				for(int j=0;j<itemData.items.Count;j++){
					if(itemData.items[j].itemID==id){
						inventory[i] = itemData.items[j];
					}
				}

				break;
			}
		}
	}
	void RemoveItem(int id){
		for (int i=0; i<inventory.Count; i++) {
			if(inventory[i].itemID == id){
				inventory[i]=new Item();
				break;
			}
		}
	}

	bool InventoryCheck(int id){
		for (int i=0; i<inventory.Count; i++)
			if(inventory[i].itemID == id)
				return true;				
		return false;
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
