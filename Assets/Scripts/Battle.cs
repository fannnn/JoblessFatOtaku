using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

	public CharacterTeam Team;
	public CharacterTeam enTeam;

	 int lineMax = 5;

	public GameObject chUnitWindow ;
	public GameObject enUnitWindow ;
	public GameObject chGrid;
	public GameObject chGraphic;

	int MeeleAtcion;
	int ArcherAtction;
	int SiegeAction;
	int DoneAction;
	bool PlayerTurn;



	void Awake(){
		//初始化定義
		Team = GameObject.Find("GameControlCenter").GetComponent<CharacterTeam> ();
		enTeam = GameObject.Find("EnemyTeam").GetComponent<CharacterTeam> ();
		chUnitWindow = GameObject.Find ("CH_UNIT");
		enUnitWindow = GameObject.Find ("EN_UNIT");
	}
	void Start () {
//		DrawGrid ();
//		DrawCTArcher ();
//		DrawCTMeele ();
//		DrawCTSiege ();
//
//		DrawENGrid ();
//		DrawENMeele ();
//		DrawENArcher ();
//		DrawENSiege ();
		PlayerTurn = true;
		SetCharacter ();

	}

	#region 設置角色
	void SetCharacter ()
	{
		for (int i=0; i<Team.ctMeele.Count; i++) {
			if (Team.ctMeele [i].chName != null) {
				GameObject chClone = Instantiate (Resources.Load<GameObject> ("CHprefab/" + Team.ctMeele [i].chID));
				Team.ctMeele [i].chUnitGO = chClone;
				chClone.GetComponent<UnitControl> ().ID = Team.ctMeele [i].chID;
				chClone.transform.SetParent (GameObject.Find ("CH_ctMeele_" + i).transform);
				chClone.transform.localPosition = new Vector2 (0, 0);
				chClone.transform.localScale = new Vector2 (1, 1);
			}
			if (Team.ctArcher [i].chName != null) {
				GameObject chClone = Instantiate (Resources.Load<GameObject> ("CHprefab/" + Team.ctArcher [i].chID));
				Team.ctArcher [i].chUnitGO = chClone;
				chClone.GetComponent<UnitControl> ().ID = Team.ctArcher [i].chID;
				chClone.transform.SetParent (GameObject.Find ("CH_ctArcher_" + i).transform);
				chClone.transform.localPosition = new Vector2 (0, 0);
				chClone.transform.localScale = new Vector2 (1, 1);
			}
			if (Team.ctSiege [i].chName != null) {
				GameObject chClone = Instantiate (Resources.Load<GameObject> ("CHprefab/" + Team.ctSiege [i].chID));
				Team.ctSiege [i].chUnitGO = chClone;
				chClone.GetComponent<UnitControl> ().ID = Team.ctSiege [i].chID;
				chClone.transform.SetParent (GameObject.Find ("CH_ctSiege_" + i).transform);
				chClone.transform.localPosition = new Vector2 (0, 0);
				chClone.transform.localScale = new Vector2 (1, 1);
			}
			if (enTeam.ctMeele [i].chName != null) {
				GameObject chClone = Instantiate (Resources.Load<GameObject> ("CHprefab/" + enTeam.ctMeele [i].chID));
				enTeam.ctMeele [i].chUnitGO = chClone;
				chClone.GetComponent<UnitControl> ().ID = enTeam.ctMeele [i].chID;
				chClone.transform.SetParent (GameObject.Find ("EN_ctMeele_" + i).transform);
				chClone.transform.localPosition = new Vector2 (0, 0);
				chClone.transform.localScale = new Vector2 (-1, 1);
			}
			if (enTeam.ctArcher [i].chName != null) {
				GameObject chClone = Instantiate (Resources.Load<GameObject> ("CHprefab/" + enTeam.ctArcher [i].chID));
				enTeam.ctArcher [i].chUnitGO = chClone;
				chClone.GetComponent<UnitControl> ().ID = enTeam.ctArcher [i].chID;
				chClone.transform.SetParent (GameObject.Find ("EN_ctArcher_" + i).transform);
				chClone.transform.localPosition = new Vector2 (0, 0);
				chClone.transform.localScale = new Vector2 (-1, 1);
			}
			if (enTeam.ctSiege [i].chName != null) {
				GameObject chClone = Instantiate (Resources.Load<GameObject> ("CHprefab/" + enTeam.ctSiege [i].chID));
				enTeam.ctSiege [i].chUnitGO = chClone;
				chClone.GetComponent<UnitControl> ().ID = enTeam.ctSiege [i].chID;
				chClone.transform.SetParent (GameObject.Find ("EN_ctSiege_" + i).transform);
				chClone.transform.localPosition = new Vector2 (0, 0);
				chClone.transform.localScale = new Vector2 (-1, 1);
			}
		}
	}
	#endregion

//	#region 格子介面與角色圖像
//	//繪製底格
//	public void DrawGrid ()
//	{
//		for (int y =0; y<3; y++)
//			for (int x =0; x<lineMax; x++) {
//				GameObject gridDraw = Instantiate (chGrid);
//				gridDraw.transform.SetParent (chUnitWindow.transform);
//				gridDraw.transform.localScale = chUnitWindow.transform.localScale;
//				float f = (chUnitWindow.transform.localScale.x);
//				gridDraw.transform.localPosition = new Vector3 (x * 60 * f, y * -60 * f, 0);
//			}
//	}
//	public void DrawENGrid ()
//	{
//		for (int y =0; y<3; y++)
//			for (int x =0; x<lineMax; x++) {
//				GameObject gridDraw = Instantiate (chGrid);
//				gridDraw.transform.SetParent (enUnitWindow.transform);
//				gridDraw.transform.localScale = enUnitWindow.transform.localScale;
//				float f = (enUnitWindow.transform.localScale.x);
//				gridDraw.transform.localPosition = new Vector3 (x * 60 * f, y * -60 * f, 0);
//			}
//	}
//	//繪製我方角色
//	public void DrawCTMeele ()
//	{
//
//		int k = 0;
//		for (int i=0; i<lineMax; i++) {
//			if (Team.ctMeele [i].chName != null) {
//				float f = (chUnitWindow.transform.localScale.x);
//				GameObject chDraw = Instantiate (chGraphic);
//				chDraw.transform.SetParent (chUnitWindow.transform);
//				chDraw.transform.localPosition = new Vector3 (i * 60 * f, 0 * f, 0);
//				chDraw.transform.localScale = chUnitWindow.transform.localScale;
//				Team.ctMeele[k].chUnit = chDraw;
//				Team.ctMeele[k].chUnit.GetComponent<HPBar>().ID = Team.ctMeele[k].chID;
//				chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + Team.ctMeele [k].chID);
//				if (Resources.Load<Sprite> ("Graphics/Pictures/" + Team.chTeam [k].chID) == null)
//					chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
//				int p = k;
//				chDraw.GetComponent<Button> ().onClick.AddListener (() => ChoseCharacter (Team.ctMeele [p].chID));
//			}
//			k++;
//		}
//	}
//	public void DrawCTArcher ()
//	{
//		int k = 0;
//		for (int i=0; i<lineMax; i++) {
//			if (Team.ctArcher [i].chName != null) {
//				float f = (chUnitWindow.transform.localScale.x);
//				GameObject chDraw = Instantiate (chGraphic);
//				chDraw.transform.SetParent (chUnitWindow.transform);
//				chDraw.transform.localPosition = new Vector3 (i * 60 * f, -60 * f, 0);
//				chDraw.transform.localScale = chUnitWindow.transform.localScale;
//				Team.ctArcher[k].chUnit = chDraw;
//				Team.ctArcher[k].chUnit.GetComponent<HPBar>().ID = Team.ctArcher[k].chID;
//				chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + Team.ctArcher [k].chID);
//				if (Resources.Load<Sprite> ("Graphics/Pictures/" + Team.ctArcher [k].chID) == null)
//					chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
//				int p = k;
//				chDraw.GetComponent<Button> ().onClick.AddListener (() => ChoseCharacter (Team.ctArcher [p].chID));
//			}
//			k++;
//		}
//	}
//	public void DrawCTSiege ()
//	{
//		int k = 0;
//		for (int i=0; i<lineMax; i++) {
//			if (Team.ctMeele [i].chName != null) {
//				float f = (chUnitWindow.transform.localScale.x);
//				GameObject chDraw = Instantiate (chGraphic);
//				chDraw.transform.SetParent (chUnitWindow.transform);
//				chDraw.transform.localPosition = new Vector3 (i * 60 * f, -120 * f, 0);
//				chDraw.transform.localScale = chUnitWindow.transform.localScale;
//				chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + Team.ctSiege [k].chID);
//				if (Resources.Load<Sprite> ("Graphics/Pictures/" + Team.ctSiege [k].chID) == null)
//					chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
//				int p = k;
//				chDraw.GetComponent<Button> ().onClick.AddListener (() => ChoseCharacter (Team.ctSiege [p].chID));
//			}
//			k++;
//		}
//	}
//
//	//繪製敵人角色
//	public void DrawENMeele ()
//	{
//		int k = 0;
//		for (int i=0; i<lineMax; i++) {
//			if (enTeam.ctMeele [i].chName != null) {
//				float f = (enUnitWindow.transform.localScale.x);
//				GameObject chDraw = Instantiate (chGraphic);
//				chDraw.transform.SetParent (enUnitWindow.transform);
//				chDraw.transform.localPosition = new Vector3 (i * 60 * f, -120 * f, 0);
//				chDraw.transform.localScale = enUnitWindow.transform.localScale;
//				chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + enTeam.ctMeele [k].chID);
//				if (Resources.Load<Sprite> ("Graphics/Pictures/" + enTeam.ctMeele [k].chID) == null)
//					chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
//				int p = k;
//				chDraw.GetComponent<Button> ().onClick.AddListener (() => ChoseCharacter (enTeam.ctMeele [p].chID));
//			}
//			k++;
//		}
//	}
//	public void DrawENArcher ()
//	{
//		int k = 0;
//		for (int i=0; i<lineMax; i++) {
//			if (enTeam.ctArcher [i].chName != null) {
//				float f = (enUnitWindow.transform.localScale.x);
//				GameObject chDraw = Instantiate (chGraphic);
//				chDraw.transform.SetParent (enUnitWindow.transform);
//				chDraw.transform.localPosition = new Vector3 (i * 60 * f, -60 * f, 0);
//				chDraw.transform.localScale = enUnitWindow.transform.localScale;
//				chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + enTeam.ctArcher [k].chID);
//				if (Resources.Load<Sprite> ("Graphics/Pictures/" + enTeam.ctArcher [k].chID) == null)
//					chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
//				int p = k;
//				chDraw.GetComponent<Button> ().onClick.AddListener (() => ChoseCharacter (enTeam.ctArcher [p].chID));
//			}
//			k++;
//		}
//	}
//	public void DrawENSiege ()
//	{
//		int k = 0;
//		for (int i=0; i<lineMax; i++) {
//			if (enTeam.ctSiege [i].chName != null) {
//				float f = (enUnitWindow.transform.localScale.x);
//				GameObject chDraw = Instantiate (chGraphic);
//				chDraw.transform.SetParent (enUnitWindow.transform);
//				chDraw.transform.localPosition = new Vector3 (i * 60 * f, 0 * f, 0);
//				chDraw.transform.localScale = enUnitWindow.transform.localScale;
//				chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/" + enTeam.ctSiege [k].chID);
//				if (Resources.Load<Sprite> ("Graphics/Pictures/" + enTeam.ctSiege [k].chID) == null)
//					chDraw.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Graphics/Pictures/404notfound");
//				int p = k;
//				chDraw.GetComponent<Button> ().onClick.AddListener (() => ChoseCharacter (enTeam.ctSiege [p].chID));
//			}
//			k++;
//		}
//	}
//	#endregion


	public void MeeleActionButton(){
		MeeleAtcion = 1;
		//GameObject.Find ("MeeleActionForward").transform.position = new Vector2 (9999, 9999);
		DoneAction += 1;
		if(DoneAction==3)
			ActionExecute ();
	}
	public void ArcherActionButton(){
		ArcherAtction = 1;
		DoneAction += 1;
		if(DoneAction==3)
			ActionExecute ();
	}
	public void SiegeActionButton(){
		SiegeAction = 1;
		DoneAction += 1;
		if(DoneAction==3)
			ActionExecute ();
	}

	public void ActionExecute(){
		List<Character> ATKerMeele;		List<Character> ATKerArcher;		List<Character> ATKerSiege;
		List<Character> DMGerMeele;		List<Character> DMGerArcher;		List<Character> DMGerSiege;
			ATKerMeele = Team.ctMeele;			ATKerArcher = Team.ctArcher;			ATKerSiege = Team.ctSiege;
			DMGerMeele = enTeam.ctMeele;			DMGerArcher = enTeam.ctArcher;			DMGerSiege = enTeam.ctSiege;
		if (PlayerTurn == false) {
			ATKerMeele = enTeam.ctMeele;			ATKerArcher = enTeam.ctArcher;			ATKerSiege = enTeam.ctSiege;
			DMGerMeele = Team.ctMeele;			DMGerArcher = Team.ctArcher;			DMGerSiege = Team.ctSiege;		}

		//meele phase
		if (MeeleAtcion == 1) {
			int meeleHPcount=0;
			int archerHPcount=0;
			int siegeHPcount=0;
			for (int i=0; i<DMGerMeele.Count; i++)
				meeleHPcount += DMGerMeele [i].chHP;
			for (int i=0; i<DMGerArcher.Count; i++)
				archerHPcount += DMGerArcher [i].chHP;
			for (int i=0; i<DMGerSiege.Count; i++)
				siegeHPcount += DMGerSiege [i].chHP;
			if(meeleHPcount>0){
				AttackByLine(ATKerMeele,DMGerMeele);print ("A");}
			else if(archerHPcount>0){
				AttackByLine(ATKerMeele,DMGerArcher);print ("B");}
			else if(siegeHPcount>0){
				AttackByLine(ATKerMeele,DMGerSiege);print ("C");}
			}


		MeeleAtcion = 0;
		ArcherAtction = 0;
		SiegeAction = 0;
		DoneAction = 0;
		PlayerTurn = !PlayerTurn;
		PhaseChange ();

	}

	void PhaseChange(){
		if(PlayerTurn==true)
			print("f");
		if (PlayerTurn == false) {
			MeeleAtcion = 1;
			ActionExecute ();
		}

	}

	//單排打單排(攻擊者排,受傷者排)
	public void AttackByLine(List<Character> ATKer,List<Character> DMGer){
		int k = Random.Range(0,lineMax);
		int l = 0;
		//攻擊方尋找
		for (int i=0; i<ATKer.Count; i++) {
			if(ATKer[i].chHP != 0)
				//挨打方尋找
			while(k<999){
				if(DMGer[k].chHP > 0){
					//傷害執行
					//動畫
					DMGer[k].chHP -= DamageStep(ATKer[i].chATK,DMGer[k].chDEF);
					k++;
					break;}
				k++;l++;
				if(k>=lineMax)
					k=0;
				if(l>lineMax)
					break;}
		}
	}
	//傷害計算(攻擊者攻擊力,受傷者HP,受傷者防禦)
	int DamageStep(int ATKerATK,int DMGerDEF){
		return(ATKerATK - (Mathf.CeilToInt(DMGerDEF / (DMGerDEF + 100))));
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
			print ("you are shock:"+ Team.chTeam[i].chName);
			break;
		}
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
