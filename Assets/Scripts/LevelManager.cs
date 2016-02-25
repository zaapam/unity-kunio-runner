using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject[] levelStyles;

	private List<GameObject> levelList;

	// Use this for initialization
	void Start () {
		levelList = new List<GameObject> ();
		levelList.Add(Instantiate(levelStyles[0]) as GameObject);
		levelList[0].transform.parent = transform;

		levelList.Add(Instantiate(levelStyles[1]) as GameObject);
		levelList[1].transform.Translate(Vector3.right * levelList[0].GetComponent<BoxCollider2D>().bounds.max.x);
		levelList[1].transform.parent = transform;

		levelList.Add(Instantiate(levelStyles[1]) as GameObject);
		levelList[2].transform.Translate(Vector3.right * levelList[1].GetComponent<BoxCollider2D>().bounds.max.x);
		levelList[2].transform.parent = transform;
		//levelList.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnBlockLevelExit(GameObject lv) {
		levelList.Remove(lv);

		GameObject obj = Instantiate(levelStyles[Random.Range(0, levelStyles.Length - 1)]) as GameObject;
		levelList.Add(obj);
		obj.transform.Translate(Vector3.right * levelList[levelList.IndexOf(obj) - 1].GetComponent<BoxCollider2D>().bounds.max.x);
	}
}
