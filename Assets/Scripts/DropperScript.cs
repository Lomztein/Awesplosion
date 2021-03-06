﻿using UnityEngine;
using System.Collections;

public class DropperScript : MonoBehaviour {

	public GameObject prefab;
	public GameObject clone;
	public GameObject clonePoint;
	public bool repeating;
	public float rate;
	public GameObject[] possibleWeapons;

	// Use this for initialization
	void Start () {
		Clone();
		if (repeating == true) {
			InvokeRepeating("Clone",rate,rate);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (clone == null) {
			Clone();
		}
	}
	void Clone () {
		clone = (GameObject)Instantiate(prefab,clonePoint.transform.position,Quaternion.identity);
		clone.GetComponent<GenericEnemyScript>().newEquip = possibleWeapons[Random.Range (0,possibleWeapons.Length)];
	}
}
