using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giroFoco : MonoBehaviour
{
    public float velocidad = 10.0F; // velocidad de giro
    public float limite = 30.0F; // angulo de giro
    public PlayerController pc;

    void Update()
    {
        if (pc.miraDerecha)
        {
            // Input.GetAxis("Vertical") va aumentando su valor del 0 al 1 cuando apretamos las teclas de ejes
            // por eso va de 0 a limite angulo. W,A,S,D tambien lo reconoce como ejes.
            float giroLimitado = Input.GetAxis("Mouse Y") * limite;
            // esta posicion toma valores de 0 a límite segun pulsemos las teclas de eje
            Quaternion objetivo = Quaternion.Euler(0, 0, giroLimitado);
            // el foco gira desde su posicion hasta objetivo si no se pulsa tecla objetivo es 0 y vuelve a su posición
            transform.rotation = Quaternion.Slerp(transform.rotation, objetivo, velocidad * Time.deltaTime);
        } 
        else
        {
            float giroLimitado = Input.GetAxis("Mouse Y") * -limite;
            Quaternion objetivo = Quaternion.Euler(0, 0, giroLimitado);
            transform.rotation = Quaternion.Slerp(transform.rotation, objetivo, velocidad * Time.deltaTime);
        }
    }
}
