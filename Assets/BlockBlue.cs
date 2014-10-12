using UnityEngine;
using System.Collections;

public class BlockBlue : MonoBehaviour {

	// 回転速度
	public float rotateSpeed = 60f;

	// 回転中フラグ
	private bool isRotate = false;

	void OnMouseDown() {
		if (isRotate) {
			return;
		}
		isRotate = true;
		StartCoroutine ("RotateDestroy");
	}

	// 回転してオブジェクトを削除する
	IEnumerator RotateDestroy() {
		float angle = 0;
		while (angle < 90) {
			angle += rotateSpeed * Time.deltaTime;
			transform.Rotate (0, rotateSpeed * Time.deltaTime, 0);
			yield return null;
		}
		Destroy (gameObject);
	}
}
