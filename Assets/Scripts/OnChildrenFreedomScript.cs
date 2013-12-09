using UnityEngine;
using System.Collections;

public class OnChildrenFreedomScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (transform.parent == null) {
			rigidbody.isKinematic = false;
			collider.enabled = true;
		}
	}
}
