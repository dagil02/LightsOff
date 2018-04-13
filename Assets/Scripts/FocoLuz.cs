using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoLuz : MonoBehaviour {
	public float disminucion;
	public FieldOfView fov;
	public Light luz;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating("DisminuyePotencia", 3, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void DisminuyePotencia(){
		fov.viewRadius = gameObject.GetComponent<Light> ().range;
		luz.range -= disminucion;
	}
	public void Reset(){
		if (fov.viewRadius < 5) {
			fov.viewRadius = 5;
			luz.range = 5;
		} else {
			fov.viewRadius = 10;
			luz.range = 10;
		}
	}
}
