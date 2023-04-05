using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoEncima : MonoBehaviour
{
    public float radio = 1.5f; // Radio de detección
    public Transform personaje; // Referencia al personaje
    public Transform camara; // Referencia a la cámara
    public int altura;
    public string texto; // Texto a mostrar

    private bool enRadio = false;

    void Update()
    {
        // Comprobar si el personaje está dentro del radio de detección
        float distanciaPersonaje = Vector3.Distance(transform.position, personaje.position);
        float distanciaCamara = Vector3.Distance(transform.position, camara.position);
        if (distanciaPersonaje <= radio || distanciaCamara <= radio) {
            enRadio = true;
        } else {
            enRadio = false;
        }
    }

    void OnGUI()
    {
        // Mostrar el texto si el personaje está dentro del radio
        if (enRadio == true) {
            Vector3 posicion = Camera.main.WorldToScreenPoint(transform.position);
            GUI.Label(new Rect(posicion.x, Screen.height - posicion.y - altura, 100, 50), texto);
        }
    }
}