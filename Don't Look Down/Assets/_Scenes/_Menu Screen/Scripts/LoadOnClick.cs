using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public void Start () {
		Cursor.visible = true;
	}

	public void LoadScene (int level) {
		Application.LoadLevel (level);
	}
}
