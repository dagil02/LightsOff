using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {
	public bool activado = false;
	PlayerController activador;
	void Start (){
		activador = GameObject.FindWithTag ("Player").GetComponent<PlayerController> ();
	}
	void Update (){
		if (activador.Activador ()) {
			if (activado) {
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
				activado = false;
			} else {
				gameObject.transform.localScale = new Vector3 (-1, 1, 1);
				activado = true;
			}
		}
	}
	/*
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Si");
		GameObject pers = other.gameObject;
		if (pers.CompareTag ("Player"))
			permiso = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("Si");
		GameObject pers = other.gameObject;
		if (pers.CompareTag ("Player"))
			permiso = false;
	}
	void Update()
	{
		if (permiso == true && Input.GetKey (KeyCode.B) && !activado) {
			activado = true;
		} else if (permiso == true && Input.GetKey (KeyCode.B) && activado) {
			activado = false;
		}
	}
	*/
}
