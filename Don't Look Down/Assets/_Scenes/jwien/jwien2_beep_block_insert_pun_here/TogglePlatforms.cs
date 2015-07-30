using UnityEngine;
using System.Collections;

public class TogglePlatforms : MonoBehaviour {

	[SerializeField] private GameObject m_RedPlatforms;
	[SerializeField] private GameObject m_BluePlatforms;
	[SerializeField] private float m_ToggleTime;

	[SerializeField] private AudioClip m_BeepClip;
	[SerializeField] private AudioClip m_SlamClip;
	[SerializeField] private float m_SoundInterval;
	[SerializeField] private int m_SoundRepeat;

	private AudioSource m_AudioSource;
	private bool showBlue = false;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource>();

		ActivatePlatforms();

		float waitTime = m_ToggleTime - (m_SoundInterval * m_SoundRepeat);
		StartCoroutine(DoIt(waitTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DoIt(float toggleTime) {
		while (true) {
			yield return new WaitForSeconds(toggleTime);
			for (int i = 0; i < m_SoundRepeat - 1; i++) {
				m_AudioSource.PlayOneShot(m_BeepClip);
				yield return new WaitForSeconds(m_SoundInterval);
			}
			m_AudioSource.PlayOneShot(m_SlamClip);

			ActivatePlatforms();
		}
	}

	void ActivatePlatforms() {
		showBlue = !showBlue;
		m_RedPlatforms.SetActive(!showBlue);
		m_BluePlatforms.SetActive(showBlue);
	}
}
