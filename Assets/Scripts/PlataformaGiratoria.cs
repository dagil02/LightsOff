﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : MonoBehaviour {
	public float VelGiro;
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, 0f, VelGiro);
	}
}
