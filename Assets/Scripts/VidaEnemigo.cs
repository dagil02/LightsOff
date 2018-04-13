using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour {
	public float dmg;
	public float maxVida;
	public float vidaRestante;
	float iniciox, inicioy;
	// Use this for initialization
	void Start () {
		iniciox = transform.position.x;
		inicioy = transform.position.y;
		gameObject.transform.GetChild (3).gameObject.SetActive (false);
		vidaRestante = maxVida;
	}
	public void Damage()
	{
		gameObject.transform.GetChild (3).gameObject.SetActive (true);
		vidaRestante -= dmg;
		if (vidaRestante <= 0)
			gameObject.SetActive (false);
	}
	public void Reset(){
		gameObject.SetActive (true);
		vidaRestante = maxVida;
		gameObject.transform.position = new Vector2 (iniciox, inicioy);
		gameObject.GetComponentInChildren<FieldOfViewEnemy> ().Detectado = false;
	}
}
