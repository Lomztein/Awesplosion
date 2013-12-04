using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	public GameObject light;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,1);
	}
	void Update() {
		if (light) {
			light.light.intensity -= 3 * Time.deltaTime;
		}
	}
}