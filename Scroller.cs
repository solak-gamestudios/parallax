using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

	public int isMenu = 0;
	// Update is called once per frame
	void Update () {
		GameObject playerMove = GameObject.FindGameObjectWithTag ("Player");
		if (playerMove != null) {
			MeshRenderer mr = GetComponent<MeshRenderer> ();
			Material mat = mr.material;
			Vector2 offset = mat.mainTextureOffset;
			if (isMenu == 0) {
				offset.x = ((playerMove.transform.position.x - transform.position.x) / transform.localScale.x) /2;
				offset.y = ((playerMove.transform.position.y - transform.position.y) / transform.localScale.y) /2;
			} else {
				offset.x += 0.001f;
				offset.y += 0.001f;
			}
			mat.mainTextureOffset = offset;
		}
	}
}
