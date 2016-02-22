using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool _jumping = false;
	public Animator anim;
	public Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Horizontal") * 1.5f;
		anim.SetFloat ("speed", Mathf.Abs(v));	
		rigidbody.velocity = new Vector2 (v, rigidbody.velocity.y);
		if (Input.GetAxis ("Horizontal") > 0) {
			//transform.Translate (Vector2.right * 1.5f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			//transform.Translate (Vector2.right * 1.5f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}



		if (Input.GetButton ("Jump") && !_jumping) {
			_jumping = true;
			anim.SetBool ("jump", true);
			rigidbody.AddForce (Vector2.up * 200.0f);
		}
		//Debug.Log ("Speed: " + v);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			_jumping = false;
			anim.SetBool ("jump", false);
		}

		Debug.Log ("Collll-" + _jumping);
	}
}
