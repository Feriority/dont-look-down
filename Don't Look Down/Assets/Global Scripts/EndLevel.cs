using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	
	void OnTriggerEnter (Collider other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.CompareTag ("winLevel")) {
			// If we're on the last level, wraps back to 0 (menu)
			Application.LoadLevel((Application.loadedLevel + 1) % Application.levelCount);
		} else if (otherObject.CompareTag ("fallToDeath")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
