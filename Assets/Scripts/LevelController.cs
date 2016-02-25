using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public LevelManager manager;

	// Use this for initialization
	void Start () {
		BoxCollider2D box = GetComponent<BoxCollider2D> ();
		Debug.Log(box.bounds.max);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GetComponentInParent<LevelManager>().OnBlockLevelExit(gameObject);
		}

		//Debug.Log(col.gameObject.tag);
	}

	void OnBecameInvisible() {
		Destroy(gameObject);

		Debug.Log("Invisible");
	}
}
