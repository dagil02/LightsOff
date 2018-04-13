using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour {
	public Light luz;
	public FieldOfView fov;
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			luz.range = 10;
			fov.viewRadius = 10;
			gameObject.SetActive (false);
		}
	}
	public void Reset(){
		gameObject.SetActive (true);
	}
}
