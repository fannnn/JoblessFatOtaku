using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item {

	public string itemName;
	public int itemID;
	public string itemInfo;
	public Texture2D itemIcon;
	public int itemPower;
	public int itemSpeed;
	public ItemType itemType;

	public enum ItemType{
		Weapon,
		Consumable,
		Quest
	}

	public Item(string name,int ID,string Info,int speed,int power,ItemType type){
		itemName = name;
		itemID = ID;
		itemInfo = Info;
		itemSpeed = speed;
		itemPower = power;
		itemType = type;

	}
	public Item(){
	}

}
