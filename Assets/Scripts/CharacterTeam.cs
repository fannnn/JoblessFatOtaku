using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterTeam : MonoBehaviour {
	public int slotsX, slotsY;
	
	public List<Character> chTeam = new List<Character>();
	public List<Character> slots = new List<Character>();
	public List<Character> ctMeele = new List<Character>();
	public List<Character> ctArcher = new List<Character>();
	public List<Character> ctSiege = new List<Character>();
	
	private CharacterData chData; 
	public UI ui;

	public int teamNum;



	
	// Use this for initialization
	void Start () {
		//初始化角色容納最大數
		for(int i = 0;i<(slotsX*slotsY);i++){
			slots.Add(new Character());
			chTeam.Add(new Character());
		}
		for (int k =0; k<5; k++) {
			ctMeele.Add(new Character());
			ctArcher.Add(new Character());
			ctSiege.Add(new Character());
		}

		

		chData = GameObject.Find("GameControlCenter").GetComponent<CharacterData> ();
		//ui = GameObject.Find ("UI(Canvas)").GetComponent<UI> ();


		if (teamNum == 0) {
			AddCharacter (1, chTeam);
			AddCharacter (2, chTeam);
			AddCharacter (3, chTeam);
			AddCharacter (7, chTeam);
			AddCharacter (8, chTeam);
			AddCharacter (9, chTeam);
			AddCharacter (10, chTeam);
			AddCharacter (10, chTeam);
			AddCharacter (10, chTeam);

		}
		if (teamNum == 1) {
			AddCharacter (4, chTeam);
			AddCharacter (5, chTeam);
			AddCharacter (6, chTeam);
		}


		//讀取隊伍資訊
//		for (int i =0; i<chTeam.Count; i++) {
//			chTeam[i] = PlayerPrefs.GetInt("chTeamID" +i, -1) >= 0 ? chData.character[PlayerPrefs.GetInt("chTeamID" + i)] : new Character();
//		}
		TeamClassify ();
	}
	public void TeamClassify(){
		for (int i =0; i<chTeam.Count; i++) {
			if(chTeam[i].chName != null){
				if(chTeam[i].chType == Character.Type.Meele)
					AddCharacter(chTeam[i].chID,ctMeele);
				if(chTeam[i].chType == Character.Type.Archer)
					AddCharacter(chTeam[i].chID,ctArcher);
				if(chTeam[i].chType == Character.Type.Siege)
					AddCharacter(chTeam[i].chID,ctSiege);
			}
		}
	}

	//新增角色
	public void AddCharacter(int ID,List<Character> chCT){
		int CTmax = 0;
		bool addOK = false;
		if(chCT == chTeam)			CTmax = (chTeam.Count);
		if (chCT == ctMeele)			CTmax = (ctMeele.Count);
		if (chCT == ctArcher)			CTmax = (ctArcher.Count);
		if (chCT == ctSiege)			CTmax = (ctSiege.Count);

		for (int i=0; i<CTmax; i++) {
			if(chCT[i].chName == null){
				for(int j=0;j<chData.character.Count;j++)
					if(chData.character[j].chID == ID){
					chCT[i] = chData.character[j];
					addOK = true;}
				break;
			}
		}
		if(addOK == false)
			print("隊伍已滿");
	}
	//移除角色
	public void RemoveCharacter(int ID){
		for (int i=0; i<chTeam.Count; i++) {
			if(chTeam[i].chID == ID){
				chTeam[i]=new Character();
				ui.RefreshCharacter();
				break;
			}
		}
	}
	//確認角色是否存在
	public bool CheckCharacter(int ID){
		for (int i=0; i<chTeam.Count; i++)
			if (chTeam [i].chID == ID) 
				return true;
		return false;
	}

	// Update is called once per frame
	void Update () {
	}
}
