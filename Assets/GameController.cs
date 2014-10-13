using UnityEngine;
using System.Collections;

public class GameController: MonoBehaviour {

	public GUITexture texClear;
	public GUITexture texFailed;

	// ステージ終了フラグ
	private bool isStageEnd;

	// Use this for initialization
	void Start () {
		texClear.enabled = false;
		texFailed.enabled = false;
		isStageEnd = false;
	}

	void Update() {
		// ステージが終了していてマウスの左クリックかタッチパネルが押されたら
		if (isStageEnd
			&& (Input.GetKey (KeyCode.Mouse0) || Input.touchCount > 0)) {
			// シーンMenuをロードする
			Application.LoadLevel ("Menu");
		}
	}

	void StageClear() {
		texClear.enabled = true;
		isStageEnd = true;
	}

	void StageFailed() {
		texFailed.enabled = true;
		isStageEnd = true;
	}
}
