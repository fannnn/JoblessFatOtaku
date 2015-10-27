using UnityEngine;
using System.Collections;

public class GameControlCenter : MonoBehaviour {
	public static GameControlCenter GCC;

	// Use this for initialization
	void Awake () {
		//控制中心唯一判定
		if (GCC == null) {
			DontDestroyOnLoad (gameObject);
			GCC = this;
		} 
		else if (GCC != this) {
			Destroy(gameObject);
		}
	}
	void Start(){
		CharacterTeam Team = GameObject.Find("GameControlCenter").GetComponent<CharacterTeam> ();
		CharacterTeam enTeam = GameObject.Find("EnemyTeam").GetComponent<CharacterTeam> ();

		Team.teamNum = 0;
		enTeam.teamNum = 1;
	}
	//儲存角色大地圖位置
	public void SavePlayerPosition(){
		PlayerMove MapPM = GameObject.Find ("MAP(Canvas)").GetComponent<PlayerMove> ();
		PlayerPrefs.SetFloat ("playerX",MapPM.Player.position.x);
		PlayerPrefs.SetFloat ("playerY",MapPM.Player.position.y);
		PlayerPrefs.SetFloat ("targetX",MapPM.Target.position.x);
		PlayerPrefs.SetFloat ("targetY",MapPM.Target.position.y);
	}
	//儲存角色隊伍資料
	public void SaveCharacterTeam(){
		CharacterTeam CHTeam = GetComponent<CharacterTeam>();
		for (int i = 0; i<CHTeam.chTeam.Count; i++) {
			PlayerPrefs.SetInt("chTeamID"+i, CHTeam.chTeam[i].chID);
		}
	}
	//儲存角色能力數值
	public void SaveCharacterData(){
		CharacterData chData = GetComponent<CharacterData> ();
		for (int i=0; i<chData.character.Count; i++) {
			PlayerPrefs.SetInt("chLV"+i,chData.character[i].chLV);
			PlayerPrefs.SetInt("chSTR"+i,chData.character[i].chSTR);
			PlayerPrefs.SetInt("chINT"+i,chData.character[i].chINT);
			PlayerPrefs.SetInt("chAGI"+i,chData.character[i].chAGI);
			PlayerPrefs.SetInt("chCHA"+i,chData.character[i].chCHA);
			PlayerPrefs.SetInt("chCOU"+i,chData.character[i].chCOU);
		}
	}


}
