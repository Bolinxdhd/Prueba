using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class DatosJuego
{
    public int puntuacionAlta;
    public int partidasJugadas;
    public DateTime ultimaPartida;

    public DatosJuego()
    {
        puntuacionAlta = 0;
        partidasJugadas = 0;
        ultimaPartida = DateTime.Now;
    }
}
