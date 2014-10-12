using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]

public class BlockGreen : MonoBehaviour {
	// ブロック破壊エフェクト用オブジェクト
	public GameObject brokenBlocksPrefab;
	// ブロックの硬さ
	public float hardness = 5f;

	// ブロック停止を判断する移動量の敷居値
	public float stopDetectMagnitude = 0.1f;

	// ブロック停止を判断する時間
	public float stopDetectTime = 1f;

	// ブロック停止判断中
	private bool isStopChecking = false;

	// ブロック停止時間
	private float stopTime;

	// ゲームコントローラーオブジェクト
	private GameObject gameController;

	void Start() {
		// シーンからGameControllerオブジェクトを取得する
		gameController = GameObject.Find ("GameController");
	}

	void Update() {
		// ブロックの移動速度が敷居値以下かチェック
		if (rigidbody.velocity.magnitude < stopDetectMagnitude) {
			if (!isStopChecking) {
				isStopChecking = true;
				// ブロックが停止いた時間を記録
				stopTime = Time.time;
			}
		} else {
			isStopChecking = false;
		}
		// 一定時間停止状態で、Floorの上で停止しているかチェック
		if(isStopChecking
			&& (Time.time - stopTime) > stopDetectTime
			&& IsGround()) {
			// GameControllerに成功を伝える
			gameController.SendMessage("StageClear");
		}
	}

	// ブロックがFloorの上に接触いているかどうか
	bool IsGround() {
		// Floorが属しているFloorレイヤーのレイヤーマスク
		int layerMaskFloor = 1 << 8;
		// ブロックの下方向にレイを発射してヒットするかチェック
		if (Physics.Raycast(transform.position, -Vector3.up,
			collider.bounds.extents.y, layerMaskFloor)) {
			return true;
		}
		return false;
	}

	// 他のColliderとぶつかったと瞬間に呼び出される
	void OnCollisionEnter(Collision collisionInfo) {
		// ぶつかった相手の速度が硬さを上回るかチェック
		if (collisionInfo.relativeVelocity.magnitude > hardness) {
			// ブロック破壊フェクト用オブジェクトをインスタンス化
			Instantiate(brokenBlocksPrefab, transform.position,
				brokenBlocksPrefab.transform.rotation);
			// オブジェクトを削除
			Destroy(gameObject);
			// GameControllerに失敗を伝える
			gameController.SendMessage ("StageFailed");
		}
	}
}
