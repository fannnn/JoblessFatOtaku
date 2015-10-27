using UnityEngine;
using System.Collections;


[System.Serializable]
public class Character {
	
	public string chName;
	public int chID;
	public int chRank;
	public int chLV;
	public int chEXP;

	public int chMaxHP;
	public int chHP;
	public int chCP;

	public Type chType;
	public int chWeapon;
	public int chArmour;

	public int chATK;
	public int chDEF;

	public int chSTR;
	public int chINT;
	public int chAGI;
	public int chCHA;
	public int chCOU;

	public string chInfo;

	public GameObject chUnitGO;
	public GameObject chFaceGO;

	public enum Type{
		Meele,
		Archer,
		Siege
	}
	
	public Character(string name,int ID,int rank,int LV,Type type,int STR,int INT,int AGI,int CHA,int COU,string Info){
		chName = name;
		chID = ID;
		chRank = rank;
		chLV = LV;

		chType = type;

		chSTR = STR;
		chINT = INT;
		chAGI = AGI;
		chCHA = CHA;
		chCOU = COU;
		chInfo = Info;		
	}
	public Character(){
		chID = -1;
	}	
	void Update(){
	}
}
