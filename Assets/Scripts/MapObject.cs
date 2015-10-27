using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour {
	public int ObjectNUM;

	void OnTriggerEnter2D(Collider2D col) {
		print ("這是村莊"+(ObjectNUM)+("號"));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
