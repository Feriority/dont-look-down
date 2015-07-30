using UnityEngine;
using System.Collections;

public class TextTimer : MonoBehaviour {

	public float displaySeconds;
	private float displaySecondsLeft;

	// Use this for initialization
	void Start () {
		displaySecondsLeft = displaySeconds;
	}
	
	// Update is called once per frame
	void Update () {
		displaySecondsLeft -= Time.deltaTime;
		if (displaySecondsLeft <= 0) {
			Destroy(gameObject);
		}
	}
}
