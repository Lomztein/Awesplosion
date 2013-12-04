using UnityEngine;
using System.Collections;

public class RemoveOutsideCamScript : MonoBehaviour {

	void OnBecameInvisible () {
		Destroy(gameObject);
		Debug.Log ("Object removed");
	}
}
