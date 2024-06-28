using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestorPuntuacion : MonoBehaviour
{
    public int puntuacionActual = 0;
    public TMP_Text textoPuntuacion;
    public Renderer rendererCanasta;
    public Material[] materialesCanasta; // Array de materiales para la canasta

    private void Start()
    {
        ActualizarPuntuacionUI();
        ActualizarMaterialCanasta();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjetoCaido"))
        {
            // Aumentar la puntuaci�n
            puntuacionActual++;

            // Actualizar el texto de la puntuaci�n
            ActualizarPuntuacionUI();

            // Actualizar la puntuaci�n alta
            GestorPuntuacionAlta.Instancia.ActualizarPuntuacionAlta(puntuacionActual);

            // Actualizar el material de la canasta
            ActualizarMaterialCanasta();

            // Destruir el objeto atrapado
            Destroy(collision.gameObject);
        }
    }

    private void ActualizarPuntuacionUI()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuaci�n: " + puntuacionActual;
        }
    }

    private void ActualizarMaterialCanasta()
    {
        if (rendererCanasta != null && materialesCanasta.Length > 0)
        {
            int indiceMaterial = puntuacionActual % materialesCanasta.Length;
            rendererCanasta.material = materialesCanasta[indiceMaterial];
        }
    }

    public void FinalizarPartida()
    {
        // Actualizar datos del juego
        GestorDatos.Instancia.datosJuego.partidasJugadas++;
        GestorDatos.Instancia.datosJuego.ultimaPartida = System.DateTime.Now;

        // Guardar datos
        GestorDatos.Instancia.GuardarDatos();

        // Finalizar el juego (esto cargar� el men� principal)
        GestorPuntuacionAlta.Instancia.FinalizarJuego(puntuacionActual);
    }
}