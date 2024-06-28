using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
    public TMP_Text textoPuntuacionAlta;
    public TMP_Text textoPartidasJugadas;
    public TMP_Text textoUltimaPartida;

    void Start()
    {
        ActualizarUI();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SalirJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    void ActualizarUI()
    {
        if (textoPuntuacionAlta != null)
        {
            textoPuntuacionAlta.text = "Récord: " + GestorDatos.Instancia.datosJuego.puntuacionAlta;
        }
        if (textoPartidasJugadas != null)
        {
            textoPartidasJugadas.text = "Partidas jugadas: " + GestorDatos.Instancia.datosJuego.partidasJugadas;
        }
        if (textoUltimaPartida != null)
        {
            textoUltimaPartida.text = "Última partida: " + GestorDatos.Instancia.datosJuego.ultimaPartida.ToString("dd/MM/yyyy HH:mm");
        }
    }
}