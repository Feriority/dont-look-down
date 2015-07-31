using UnityEngine;
using System.Collections;

public class ToggleWinCondition : MonoBehaviour {

	[SerializeField] private GameObject m_DisappearPlatforms;
	[SerializeField] private GameObject m_AppearPlatforms;
	[SerializeField] private float m_ToggleTime;

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		StartCoroutine(Toggle());
	}

	IEnumerator Toggle(){
		m_DisappearPlatforms.SetActive(false);
		m_AppearPlatforms.SetActive(true);
		yield return new WaitForSeconds(m_ToggleTime);
		m_AppearPlatforms.SetActive(false);
		m_DisappearPlatforms.SetActive(true);
	}
}