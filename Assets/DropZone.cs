using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour {
	// GameController
	private GameObject gameController;

	void Start () {
		// シーンからGameControllerオブジェクトを取得する
		gameController = GameObject.Find("GameController");
	}

	// 他のColliderがヒットした瞬間	
	void OnTriggerEnter (Collider other) {
		if (other.name == "BlockGreen") {
			// 緑ブロックがヒットしたらゲームコントローラーに失敗を通知
			gameController.SendMessage("StageFailed");
		}
		// ヒットしたオブジェクトを削除する
		Destroy(other.gameObject);
	}
}
