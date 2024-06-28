using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestorPuntuacionAlta : MonoBehaviour
{
    public static GestorPuntuacionAlta Instancia { get; private set; }

    public TMP_Text textoPuntuacionAlta;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Asegúrate de que GestorDatos se inicialice primero
        if (GestorDatos.Instancia == null)
        {
            GameObject gestorDatosObj = new GameObject("GestorDatos");
            gestorDatosObj.AddComponent<GestorDatos>();
        }
    }

    private void Start()
    {
        ActualizarUIpuntuacionAlta();
    }

    public void ActualizarPuntuacionAlta(int nuevaPuntuacion)
    {
        if (GestorDatos.Instancia != null && nuevaPuntuacion > GestorDatos.Instancia.datosJuego.puntuacionAlta)
        {
            GestorDatos.Instancia.datosJuego.puntuacionAlta = nuevaPuntuacion;
            GestorDatos.Instancia.GuardarDatos();
            ActualizarUIpuntuacionAlta();
        }
    }

    private void ActualizarUIpuntuacionAlta()
    {
        if (textoPuntuacionAlta != null && GestorDatos.Instancia != null)
        {
            textoPuntuacionAlta.text = "Récord: " + GestorDatos.Instancia.datosJuego.puntuacionAlta;
            Debug.Log("Récord actualizado: " + GestorDatos.Instancia.datosJuego.puntuacionAlta);
        }
        else
        {
            if (textoPuntuacionAlta == null)
                Debug.LogWarning("textoPuntuacionAlta no está asignado en GestorPuntuacionAlta.");
            if (GestorDatos.Instancia == null)
                Debug.LogWarning("GestorDatos.Instancia es null.");
        }
    }

    public void FinalizarJuego(int puntuacionFinal)
    {
        ActualizarPuntuacionAlta(puntuacionFinal);
        if (GestorDatos.Instancia != null)
        {
            GestorDatos.Instancia.datosJuego.partidasJugadas++;
            GestorDatos.Instancia.datosJuego.ultimaPartida = System.DateTime.Now;
            GestorDatos.Instancia.GuardarDatos();
        }
        SceneManager.LoadScene("Menu");
    }
}