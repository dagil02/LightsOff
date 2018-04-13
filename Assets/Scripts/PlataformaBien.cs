using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaBien : MonoBehaviour {
	public GameObject platform;
	public float speed;
	Transform currentpoint;
	public Transform[] points;
	public int pointselection;
	Quaternion Rotacion;
	// Use this for initialization
	void Start () {
		currentpoint = points [pointselection];
		Rotacion = this.gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentpoint.position, Time.deltaTime * speed);
			if (platform.transform.position == currentpoint.position) {
				pointselection++;
				if (pointselection == points.Length)
					pointselection = 0;
			}
			currentpoint = points [pointselection];
			this.gameObject.transform.rotation = Rotacion;
	}
}
