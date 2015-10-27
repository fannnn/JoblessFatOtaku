using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnitControl : MonoBehaviour {

	public GameObject bar;
	public CharacterTeam Team;
	public CharacterTeam enTeam;
	public CharacterData chDT;
	public int ID;
	int ch;

	// Use this for initialization
	void Start () {
		Team = GameObject.Find("GameControlCenter").GetComponent<CharacterTeam> ();
		enTeam = GameObject.Find("EnemyTeam").GetComponent<CharacterTeam> ();
		chDT = GameObject.Find ("GameControlCenter").GetComponent<CharacterData> ();

		for (int i=0; i<chDT.character.Count; i++)
			if (chDT.character[i].chID == ID) {
			ch = i;
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
		float i = 1f/chDT.character[ch].chMaxHP ;
		bar.transform.localScale= new Vector2 (chDT.character[ch].chHP*i,1);

	}
}
