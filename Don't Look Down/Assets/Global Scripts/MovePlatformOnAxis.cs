using UnityEngine;
using System.Collections;

public class MovePlatformOnAxis : MonoBehaviour {

	[SerializeField] private float minPos;
	[SerializeField] private float maxPos;
	[SerializeField] private float moveSpeed;  // Units per second
	[SerializeField] private float pauseLength;
	[SerializeField] private char axis;
	
	private bool forward;
	private bool isPaused;
	private float pauseTimer;
	private int axisOrd;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		forward = true;
		if (axis == 'x' || axis == 'X') {
			axisOrd = 0;
			direction = Vector3.right;
		} else if (axis == 'y' || axis == 'Y') {
			axisOrd = 1;
			direction = Vector3.up;
		} else if (axis == 'z' || axis == 'Z') {
			axisOrd = 2;
			direction = Vector3.forward;
		} else {
			throw new UnityException("INVALID AXIS");
		}
		Pause();
	}
	
	// FixedUpdate is called once per frame, before physics
	void FixedUpdate () {
		if (isPaused) {
			pauseTimer -= Time.deltaTime;
			if (pauseTimer <= 0) {
				forward = !forward;
				isPaused = false;
			}
		} else {
			float deltaPos = moveSpeed * Time.deltaTime;
			if (!forward) {
				deltaPos *= -1;
			}

			// Switch from translation to position to do bounds checking
			float newPos = gameObject.transform.position[axisOrd] + deltaPos;
			if (forward && newPos >= maxPos) {
				newPos = maxPos;
				Pause();
			} else if (!forward && newPos <= minPos) {
				newPos = minPos;
				Pause();
			}

			// Switch back to translation and move the object
			deltaPos = newPos - gameObject.transform.position[axisOrd];
			gameObject.transform.Translate(direction * deltaPos);
		}
	}

	void Pause() {
		isPaused = true;
		pauseTimer = pauseLength;
	}
}
