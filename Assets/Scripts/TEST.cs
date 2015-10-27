using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TEST : MonoBehaviour {

	public int PlayerHealth;
	public int PlayerATK;

	public int EnemyHealth;
	public int EnemyATK;

	public int AttackerType;
	public int DefenderType;

	public int Damage;

	public GameObject TextBOX;
	public GameObject PlayerHPText;
	public GameObject EnemyHPText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


//		PlayerHPText.GetComponent<Text> ().text = ("HP:" + PlayerHealth);
//		EnemyHPText.GetComponent<Text>().text = ("HP:"+ EnemyHealth);
//		if (AttackerType == 1){
//			if(DefenderType == 1){
//				TextBOX.GetComponent<Text>().text = ("你急忙往後一跳，敵人卻趁勢追上直刺，遭受重擊！");
//				PlayerHealth -= 30;
//			}
//			if(DefenderType == 2){
//				TextBOX.GetComponent<Text>().text = ("你往後一跳，敵人掃了個空。");}
//			if(DefenderType == 3){
//				TextBOX.GetComponent<Text>().text = ("敵人快速的攻擊，你往後一跳卸去了大部分力道，但仍受到一些傷害。");
//				PlayerHealth -= 20;}
//
//		}
//		AttackerType = 0;
//		DefenderType = 0;

	}
	public void PlayerAttackPhase(){
		print ("fkcke");
		int AttackerRandom;
		int DefenderRandom;
		AttackerRandom = (Random.Range (1,4));
		DefenderRandom = (Random.Range (1,4));
		Damage = (PlayerATK*1)+((AttackerRandom)*(PlayerATK/5))-((DefenderRandom)*(EnemyHealth/50));
		if (AttackerType == 1) {
			if(DefenderType == 1){Damage*=3;}
			if(DefenderType == 2){Damage=0;}
			if(DefenderType == 3){Damage*=2;}
		}
		if (AttackerType == 2) {
			if(DefenderType == 1){Damage*=0;}
			if(DefenderType == 2){Damage=3;}
			if(DefenderType == 3){Damage*=2;}
		}
		if (AttackerType == 3) {
			if(DefenderType == 1){Damage*=2;}
			if(DefenderType == 2){Damage=2;}
			if(DefenderType == 3){Damage*=1;}
		}
		EnemyHealth -= Damage;




		string PName="";
		string EName="";
		string A1="";
		string A2="";
		string B1="";
		string B2="";
		string C="";
		//string Dialog="";
		PName = "你";
		EName = "敵人";

		if (AttackerRandom == 1)A1 = "快速的";
		if (AttackerRandom == 2)A1 = "奮力的";
		if (AttackerRandom == 3)A1 = "毫不留情的";
		if(AttackerType ==1)A2 = "往前突刺";
		if(AttackerType ==2)A2 = "橫掃了前方";
		if(AttackerType ==3)A2 = "發動兩次連擊";

		if(DefenderRandom == 1)B1 = "急忙";
		if(DefenderRandom == 2)B1 = "緊急";
		if(DefenderRandom == 3)B1 = "反射性";
		if(DefenderType ==1)B1 = "往後一跳";
		if(DefenderType ==2)B1 = "閃向側邊";
		if(DefenderType ==3)B1 = "舉起武器招架";

		if (AttackerType == 1) {
			if(DefenderType==1)C="被捅個正著！";
			if(DefenderType==2)C="輕巧的閃過。";
			if(DefenderType==3)C="盡力擋住了攻擊，但手腕仍被震得酸麻。";
		}

		//if(A1!=null)if(A2!=null)if(B1!=null)if(B2!=null)if(C!=null)if(PName!=null)if(EName!=null)
		TextBOX.GetComponent<Text> ().text = PName + A1 + A2 + "，" + EName + B1 + B2 + C;

	
	
	
	}











	public void AttackerType1(){
		DefenderType = Random.Range (1, 4);
		AttackerType = 1;
		PlayerAttackPhase ();
	}
	public void AttackerType2(){
		DefenderType = Random.Range (1, 4);
		AttackerType = 2;
		PlayerAttackPhase ();
	}
	public void AttackerType3(){
		DefenderType = Random.Range (1, 4);
		AttackerType = 3;
		PlayerAttackPhase ();
	}


}
