using UnityEngine;
using System.Collections;

public class Inactivate : MonoBehaviour {

	[SerializeField] private GameObject m_objects;

	// Use this for initialization
	void Start () {
		m_objects.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
