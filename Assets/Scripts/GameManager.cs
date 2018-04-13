using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestor del juego (singleton simplificado). Controlará el estado del juego
/// y tendrá métodos llamados desde los distintos objetos que lo hacen avanzar.
/// Debe haber una única instancia. 
/// </summary>
public class GameManager : MonoBehaviour {

	// Creamos una variable estática para almacenar la instancia única
	public static GameManager instance = null;
	public GameObject currentcheckpoint;
	PlayerController player;
	VidaEnemigo [] enemigo;
	FocoLuz luz;
	Bateria[] pila;
	boxpull [] box;

	// En cuanto el objeto se active
	void Awake() {
		// Si no hay ningún objeto GameManager ya creado
		if (instance == null) {
			// Almacenamos la instancia actual
			instance = this;
			// Nos aseguramos de no destruir el objeto, es decir, 
			// de que persista, si cambiamos de escena
			DontDestroyOnLoad(this.gameObject);
		}
		else {
			// Si ya existe un objeto GameManager, no necesitamos uno nuevo
			Destroy(this.gameObject);
		}
		player = FindObjectOfType<PlayerController> ();
		enemigo = FindObjectsOfType<VidaEnemigo> ();
		luz = FindObjectOfType<FocoLuz> ();
		pila = FindObjectsOfType<Bateria> ();
		box = FindObjectsOfType<boxpull> ();
	}
	public void RespawnPlayer()
	{
		player.transform.position = currentcheckpoint.transform.position;
		for (int i = 0; i < enemigo.Length; i++) {
			enemigo [i].Reset ();
		}
		for (int i = 0; i < pila.Length; i++) {
			pila [i].Reset ();
		}
		for (int i = 0; i < box.Length; i++) {
			box [i].Reset ();
		}
		luz.Reset ();
	}

	// A partir de aquí añadiríamos los métodos que necesitemos implementar
	// para conseguir las funcionalidades que pretendamos incluir. 
}

