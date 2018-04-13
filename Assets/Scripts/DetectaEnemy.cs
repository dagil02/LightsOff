using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaEnemy : MonoBehaviour {
	public float dmg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D (Collider2D col){
		GameObject enemigo = col.gameObject;
		if (enemigo.CompareTag ("Enemy")) {
			VidaEnemigo v = enemigo.GetComponent <VidaEnemigo>();
			v.Damage ();
		}
	}
}
