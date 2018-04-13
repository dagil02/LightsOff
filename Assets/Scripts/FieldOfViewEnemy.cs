using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewEnemy : MonoBehaviour {
	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;
	public LayerMask targetMask;
	public LayerMask obstacleMask;
	public List<Transform> visibleTargets = new List<Transform>();
	public bool Detectado;

	void Start(){
		InvokeRepeating ("FindVisibleTargets", 0f, 0.2f);
	}
	/*IEnumerator FindTargetsWithDelay(float delay){
		while (true)
		{
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}*/
	//Busca a los objetivos dentro del campo de visión que no estén bloqueados por muros
	void FindVisibleTargets(){
		visibleTargets.Clear ();
		//Añade los objetivos en el RADIO de vision (no campo de visión, pueden estar detrás) a un array
		Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll (transform.position, viewRadius, targetMask);
		//Comprueba para cada objetivo en el RADIO de visión si está en el CAMPO de visión
		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			Transform target = targetsInViewRadius [i].transform;
			//Hallamos el vector que indica la dirección que hay del objetivo al jugador
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			//Si el objetivo está en el ángulo de visión, hallado con los vectores directores de la dirección hacia la que mira
			//el jugador y el vector que indica la dirección que hay del objetivo al jugador.
			if (Vector3.Angle (transform.up, dirToTarget) < viewAngle / 2) {
				//Hallamos la distancia entre ambos
				float dstToTarget = Vector3.Distance (transform.position, target.position);
				//Si no hay ningún obstáculo en medio, añade el objetivo a la lista de objetivos visibles
				if (!Physics2D.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
					visibleTargets.Add (target);
					Detectado = true;
				}
			} else
				Detectado = false;
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
		if (!angleIsGlobal) {
			angleInDegrees -= transform.eulerAngles.z;
		}
		return new Vector3(Mathf.Sin(angleInDegrees*Mathf.Deg2Rad),Mathf.Cos(angleInDegrees*Mathf.Deg2Rad), 0);
	}
}