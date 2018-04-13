using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAenemigo : MonoBehaviour {
	bool suelo = false, izq = false, detectado = false;
	public Transform detector, posSuelo;
	public float probabilidad;
	float vel;
	private float probabilidadF;
	Rigidbody2D rb;
	Vector2 dir;
	public Transform cabeza;
	FieldOfViewEnemy fove;
	// Use this for initialization
	void Start () {
		vel = 2.5f;
		rb = GetComponent <Rigidbody2D> ();
		dir = new Vector2 (10f, 0);
		probabilidadF = probabilidad;
		fove = GetComponentInChildren <FieldOfViewEnemy> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		detectado = fove.Detectado;
		//Vector2 v2 = new Vector2 (cabeza.position.x, cabeza.position.y);
		rb.velocity = new Vector2 (vel, 0f);
		//Debug.Log ("agua");
		//RaycastHit2D hit = Physics2D.Raycast (v2,dir,1000);
		/*if (hit.collider != null && hit.collider.gameObject.tag == "Player")
			detectado = true;
		if (hit.collider == null) {
			Debug.Log ("agua");
		}
*/
		if (detectado) {
			probabilidadF = 0f;
			if (transform.localScale.x > 0)
				vel = 5f;
			else
				vel = -5f;
		} else {
			probabilidadF = probabilidad;
			if (transform.localScale.x > 0)
				vel = 2.5f;
			else
				vel = -2.5f;
		}

		suelo =  Physics2D.Linecast(detector.position, posSuelo.position, 1 << LayerMask.NameToLayer("Plataformas"));
		if (!suelo && !detectado)
			Gira();
		else if (!suelo && detectado)
			rb.velocity = new Vector2 (0f, 0f);	

		if (probabilidadF > Random.value) {
			Gira ();
		}

	}

	void Gira (){
		izq = !izq;
		float sx = this.gameObject.transform.localScale.x;
		float sy = this.gameObject.transform.localScale.y;
		sx *= -1;
		this.gameObject.transform.localScale = new Vector2 (sx, sy);
		vel *= -1;
		dir = new Vector2 (-dir.x, dir.y);
	}


}