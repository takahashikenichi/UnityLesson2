using UnityEngine;
using System.Collections;

public class BlockRed : MonoBehaviour {

	void OnMouseDown() {
		// クリックされるとオブジェクトを削除する
		Destroy (gameObject);
	}
}
