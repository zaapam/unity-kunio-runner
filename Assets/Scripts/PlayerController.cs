using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool isJump = false;
	private float speed = 0;
	private Animator anim;
	private Rigidbody2D rigid;

	public float force = 1.5f;
	public float maxSpeed = 3.0f;
	public float acceleration = 1.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Horizontal") * 1.5f;
		anim.SetFloat ("speed", Mathf.Abs(v));	
		//rigid.velocity = new Vector2 (v, rigid.velocity.y);
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Translate (Vector2.right * 1.5f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (Vector2.right * 1.5f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}



		if (Input.GetButton ("Jump") && rigid.velocity.y == 0 && !isJump) {
			isJump = true;
			anim.SetBool ("jump", true);
			//rigidbody.AddForce (Vector2.up * 200.0f);
			rigid.velocity = new Vector2(rigid.velocity.x, 4.0f);

			Debug.Log ("OnJump");
		}
		//Debug.Log ("Speed: " + v);

		//Run();
	}

	void Run() {
		//rigid.AddForce(Vector2.right * force);
		//rigid.velocity = Vector2.right * 2.0f;

		if (speed < maxSpeed && !isJump) {
			//rigid.AddForce(Vector2.right * 4.0f);
			//Debug.Log("AddForce");
			speed = speed + acceleration * Time.deltaTime;
		}
			
		//rigid.MovePosition(new Vector2(rigid.position.x + (speed * Time.deltaTime), rigid.position.y));
		//rigid.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		anim.SetFloat ("speed", Mathf.Abs(speed));

		Debug.Log("Character velocity : " + rigid.velocity.x);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isJump = false;
			anim.SetBool ("jump", false);
			rigid.velocity = Vector2.right * rigid.velocity.x;

			Debug.Log ("OnGround");
		}


	}
}
