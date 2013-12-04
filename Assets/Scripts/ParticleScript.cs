using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	public GameObject missleLight;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,1);
	}
	void Update() {
		if (missleLight) {
			missleLight.light.intensity -= 3 * Time.deltaTime;
		}
	}
}