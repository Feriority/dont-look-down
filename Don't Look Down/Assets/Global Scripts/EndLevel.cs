using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	
	void OnTriggerEnter (Collider other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.CompareTag ("endlevel")) {
			Application.LoadLevel(0);
		}
	}
}
