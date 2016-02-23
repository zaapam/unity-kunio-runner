using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject[] levelStyles;

	private List<GameObject> levelList;

	// Use this for initialization
	void Start () {
		levelList = new List<GameObject> ();
		GameObject l = Instantiate(levelStyles[0]);
		l.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnBlockLevelExit(LevelController lv) {
		
	}
}
