using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterData : MonoBehaviour {
	public List<Character> character = new List<Character>();
	
	void Start(){
		//初始化角色
		character.Add(new Character("zzzz",0,5,10,Character.Type.Meele,3,2,5,0,2,"just a fukc"));
		character.Add(new Character("Hero",1,5,10,Character.Type.Meele,5,2,5,0,2,"just a hero"));
		character.Add(new Character("Shoot to kill",2,5,10,Character.Type.Archer,2,2,5,0,2,"just a hero"));
		character.Add(new Character("Science MDFK",3,5,10,Character.Type.Siege,1,2,5,0,2,"just a hero"));
		character.Add(new Character("ENMeele",4,5,10,Character.Type.Meele,4,2,5,0,2,"just a hero"));
		character.Add(new Character("ENArcher",5,5,10,Character.Type.Archer,1,2,5,0,2,"just a hero"));
		character.Add(new Character("ENSiege",6,5,10,Character.Type.Siege,1,2,5,0,2,"just a hero"));
		character.Add(new Character("Hero",7,5,10,Character.Type.Meele,5,2,5,0,2,"just a hero"));
		character.Add(new Character("Hero",8,5,10,Character.Type.Meele,5,2,5,0,2,"just a hero"));
		character.Add(new Character("Hero",9,5,10,Character.Type.Meele,5,2,5,0,2,"just a hero"));
		character.Add(new Character("Hero",10,5,10,Character.Type.Meele,5,2,5,0,2,"just a hero"));


//		//讀取儲存數值
//		for (int i=0; i<character.Count; i++) {
//			character [i].chLV = PlayerPrefs.GetInt ("chLV" + i);
//			character [i].chSTR = PlayerPrefs.GetInt ("chSTR" + i);
//			character [i].chINT = PlayerPrefs.GetInt ("chINT" + i);
//			character [i].chAGI = PlayerPrefs.GetInt ("chAGI" + i);
//			character [i].chCHA = PlayerPrefs.GetInt ("chCHA" + i);
//			character [i].chCOU = PlayerPrefs.GetInt ("chCOU" + i);
//		}

		//初始化角色HP以及其他定義
		for (int i=0; i<character.Count; i++) {
			character [i].chMaxHP = character [i].chSTR*10;
			character[i].chATK= character[i].chSTR + character[i].chAGI;
			character[i].chDEF= character[i].chAGI;
		}
		for (int i=0; i<character.Count; i++) {
			character [i].chHP = character [i].chMaxHP;
		}
	}


	void Update(){
		//禁止扣血扣到負數
		for (int i=0; i<character.Count; i++) {
			if(character[i].chHP<=0)
				character[i].chHP=0;
		}		
		for (int i=0; i<character.Count; i++) {
			if(character[i].chHP>=character[i].chMaxHP)
				character[i].chHP=character[i].chMaxHP;
		}

		
	}

}
