using UnityEngine;
using System.Collections;

public class healthScript : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float regenSpeed;
	public float regenLimit;
	public bool invinsible;
	public GameObject debris;
	
	// Update is called once per frame
	void Update () {
		if (health >= maxHealth) {
			health = maxHealth;
		}
		if (health < regenLimit) {
			health += regenSpeed * Time.deltaTime;
		}
		if (health <= 0 && invinsible == false) {
			Destroy(gameObject);
			if (debris) {
				GameObject scatter = (GameObject)Instantiate(debris,transform.position,transform.rotation);
				scatter.rigidbody.AddForce(rigidbody.velocity);
			}
		}
	}
}
