using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public GameObject TeamGO;
	public CharacterTeam Team;


	public bool TeamShow =false;

	public GameObject chUnitWindow ;
	public GameObject chGrid;
	public GameObject chGraphic;

	public Text NAME;
	public Text LV;
	public Text STR;
	public Text INT;
	public Text AGI;
	public Text CHA;
	public Text COU;
	public Image chFace;

	// Use this for initialization
	void Start () {
		Team = GameObject.FindGameObjectWithTag ("GCC").GetComponent<CharacterTeam> ();
		chUnitWindow = GameObject.Find ("CH_UNIT");
		chFace = GameObject.Find("CharacterFace").GetComponent<Image>();
		NAME = GameObject.Find ("NAME").GetComponent<Text>();
		LV= GameObject.Find ("LV").GetComponent<Text>();
		STR= GameObject.Find ("STR").GetComponent<Text>();
		INT= GameObject.Find ("INT").GetComponent<Text>();
		AGI= GameObject.Find ("AGI").GetComponent<Text>();
		CHA= GameObject.Find ("CHA").GetComponent<Text>();
		COU= GameObject.Find ("COU").GetComponent<Text>();
		
		DrawGrid ();
		DrawCH ();
	
	}
	
	// Update is called once per frame
	void Update () {	
	}

	//繪製底格
	public void DrawGrid(){
		DestroyAllchGrid();
		for (int y =0; y<Team.slotsY; y++)
		for (int x =0; x<Team.slotsX; x++) {
			GameObject gridDraw = Instantiate (chGrid);
			gridDraw.transform.SetParent(chUnitWindow.transform);
			gridDraw.transform.localScale = chUnitWindow.transform.localScale;
			float f = (chUnitWindow.transform.localScale.x);
			gridDraw.transform.localPosition = new Vector3(x*105*f,y*-105*f,0);
		}
	}
	//繪製角色
	public void DrawCH(){
		DestroyAllCharacterGraphic();
		int k = 0;
		for (int y =0; y<Team.slotsY; y++)
		for (int x =0; x<Team.slotsX; x++) {
			//slots [k] = Team.chTeam [k];
			if (Team.chTeam[k].chName != null){
				GameObject chDraw = Instantiate (chGraphic);
				chDraw.transform.SetParent(chUnitWindow.transform);
				float f = (chUnitWindow.transform.localScale.x);
				chDraw.transform.localPosition = new Vector3(x*105*f,y*-105*f,0);
				chDraw.transform.localScale = chUnitWindow.transform.localScale;
				chDraw.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Pictures/"+Team.chTeam[k].chID);
				if(Resources.Load<Sprite>("Graphics/Pictures/"+Team.chTeam[k].chID) == null)
					chDraw.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Pictures/404notfound");
				int p = k;
				chDraw.GetComponent<Button>().onClick.AddListener(()=>ChoseCharacter(Team.chTeam[p].chID));
			}
			k++;
		}
	}
	//刷新角色欄位
	public void RefreshCharacter(){
		//清空Team.chTeam欄位並將資料轉移至slots欄位
		for (int j=0; j<Team.chTeam.Count; j++) {
			Team.slots [j] = Team.chTeam [j];
			Team.chTeam [j] = new Character ();
		}
		//重新轉移slots欄位內的單位一一進入Team.chTeam的空欄位
		for (int i=0; i<Team.chTeam.Count; i++)
		if (Team.slots [i].chName != null) {
			for (int l=0; l<Team.chTeam.Count; l++)
			if (Team.chTeam [l].chName == null){
				Team.chTeam [l]= Team.slots [i] ;
				break;
			}
		}		
	}
	
	//角色按下
	public void ChoseCharacter(int ID){
		for (int i=0; i<Team.chTeam.Count; i++)
		if (Team.chTeam [i].chID == ID) {
			DrawCharacterInfo (i);				
			DrawCH();
			break;
		}
	}
	//繪製角色資訊
	public void DrawCharacterInfo(int i){
		NAME.text =""+ Team.chTeam [i].chName;
		LV.text ="等級:"+ Team.chTeam [i].chLV;
		STR.text ="力量:"+ Team.chTeam [i].chSTR;
		INT.text ="智慧:"+ Team.chTeam [i].chINT;
		AGI.text ="敏捷:"+ Team.chTeam [i].chAGI;
		CHA.text ="魅力:"+ Team.chTeam [i].chCHA;
		COU.text ="勇氣:"+ Team.chTeam [i].chCOU;

		if (Resources.Load<Sprite> ("Graphics/Pictures/" + Team.chTeam [i].chID) != null)
			chFace.sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + Team.chTeam [i].chID);
		else
			chFace.sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
	}
	//消除所有角色圖片
	public void DestroyAllCharacterGraphic(){
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("chGraphic"))
			Destroy(o);	
	}
	//消除所有格子
	public void DestroyAllchGrid(){
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("chGrid"))
			Destroy(o);	
	}
	public void ChTeamScrollbar(){		
		//隊伍的滑動軸
		float v = GameObject.Find ("Scrollbar").GetComponent<Scrollbar> ().value;
		int max = 580;
		chUnitWindow.transform.localPosition = new Vector3 (chUnitWindow.transform.localPosition.x, 185+(v * max),chUnitWindow.transform.localPosition.z);
	}










	//隊伍選單
	public void TeamButton(){
		switch (TeamShow) {
		case true:
			TeamGO.transform.localPosition = new Vector3(0,0,0);
			TeamShow =false;
			break;
		case false:
			TeamGO.transform.localPosition = new Vector3(10000,0,0);
			TeamShow =true;
			break;		
		}
	}

	//換場景
	public void change(){
		if (Application.loadedLevelName == ("Map")) {
			GameObject.FindWithTag("GCC").GetComponent<GameControlCenter>().SavePlayerPosition();
			Application.LoadLevel ("TeamFight");
		}
		if(Application.loadedLevelName == ("TeamFight"))
			Application.LoadLevel("Map");
	}


}
