using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public Transform Player;
	public Transform Target;
	public Transform Cam;

	public float DisX;
	public float DisY;
	public float SPD;
	// Use this for initialization
	void Start () {
		//初始化定義
		Player = GameObject.Find ("Player").transform;
		Target = GameObject.Find ("Target").transform;
		Cam = GameObject.Find ("Main Camera").transform;

		//讀取先前位置
		Player.position =new Vector2(PlayerPrefs.GetFloat("playerX"),PlayerPrefs.GetFloat("playerY"));
		Target.position =new Vector2(PlayerPrefs.GetFloat("targetX"),PlayerPrefs.GetFloat("targetY"));
	}

	public void MapPress(){
		//滑鼠偵測，目標移動
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		Target.position = new Vector3(hit.point.x,hit.point.y,Target.position.z);
	}
	// Update is called once per frame
	void Update () {
		if (Player != null) {
			//攝影機綁定玩家位置
			Cam.position = Player.position;
			//玩家追蹤定位
			float x = 0;
			float y = 0;
			x = Mathf.Abs (Player.position.x - Target.position.x);
			y = Mathf.Abs (Player.position.y - Target.position.y);
			DisX = x / (x + y);
			DisY = y / (x + y);
			//玩家向目標移動
			if (Player.position.x < Target.position.x)
				Player.position += new Vector3 (DisX * SPD, 0, 0);
			if (Player.position.x > Target.position.x)
				Player.position -= new Vector3 (DisX * SPD, 0, 0);
			if (Player.position.y < Target.position.y)
				Player.position += new Vector3 (0, DisY * SPD, 0);
			if (Player.position.y > Target.position.y)
				Player.position -= new Vector3 (0, DisY * SPD, 0);
		}
	}
}
