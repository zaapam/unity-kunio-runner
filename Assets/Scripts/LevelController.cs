using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public LevelManager manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "player") {
			manager.OnBlockLevelExit(this);
		}
	}
}
