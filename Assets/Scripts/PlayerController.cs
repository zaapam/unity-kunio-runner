using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Horizontal") * 1.5f;
		anim.SetFloat ("speed", Mathf.Abs(v));	
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (v, 0.0f);
		if (Input.GetAxis ("Horizontal") > 0) {
			//transform.Translate (Vector2.right * 1.5f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			//transform.Translate (Vector2.right * 1.5f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}


		//Debug.Log ("Speed: " + v);
	}
}
