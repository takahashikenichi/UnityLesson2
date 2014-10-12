using UnityEngine;
using System.Collections;

public class GameController: MonoBehaviour {

	public GUITexture texClear;
	public GUITexture texFailed;

	// Use this for initialization
	void Start () {
		texClear.enabled = false;
		texFailed.enabled = false;
	
	}

	void StageClear() {
		texClear.enabled = true;
	}

	void StageFailed() {
		texFailed.enabled = true;
	}
}
