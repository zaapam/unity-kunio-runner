using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private BoxCollider2D collider;

	public LevelManager manager;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		//Debug.Log(box.bounds.max);
	}
	
	// Update is called once per frame
	void Update () {
		CheckInvisible();
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GetComponentInParent<LevelManager>().OnBlockLevelExit(gameObject);
		}

		//Debug.Log(col.gameObject.tag);
	}

	void CheckInvisible() {
		if (!collider.bounds.IsVisibleFrom(Camera.main)) {
			Debug.Log("******************Invisible");

			//gameObject.SetActive(false);
			Destroy(gameObject);
		}

		Debug.Log("Visible");
	}
}
