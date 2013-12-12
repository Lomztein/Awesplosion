using UnityEngine;
using System.Collections;

public class DrawTriggerScript : MonoBehaviour {

	public LineRenderer lineRenderer;
	public Transform originObject;
	public GameObject destinationObject;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		originObject = GetComponent<Transform>();
		destinationObject = transform.parent.GetComponent<ActivateableObjectScript>().button.gameObject;
		lineRenderer.SetWidth (0.5f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (originObject && destinationObject) {
			lineRenderer.SetPosition(0,originObject.position);
			lineRenderer.SetPosition(1,destinationObject.transform.position);
		}
	}
}
