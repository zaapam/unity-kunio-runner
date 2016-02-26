using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

	public Vector2 speed = new Vector2(2, 2);
	public Vector2 direction = new Vector2(-1, 0);
	public Transform target;

	private Vector3 lastPosition;

	void Update() {
		Vector3 movement;

		if (target) {
			if (lastPosition == null) {
				lastPosition = new Vector3(target.transform.position.x, 0, 0);
				movement = Vector3.zero;
			} else {
				movement = new Vector3((target.transform.position.x - lastPosition.x) * -1 * speed.x, 0, 0);
				lastPosition = new Vector3(target.transform.position.x, 0, 0);

				Debug.Log(movement);
			}

			transform.Translate(movement);
		} else {
			movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
			movement *= Time.deltaTime;
			transform.Translate(movement);	
		}
	}
}