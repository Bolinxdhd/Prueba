using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GestorDatos : MonoBehaviour
{
    public static GestorDatos Instancia { get; private set; }
    public DatosJuego datosJuego;

    private string rutaArchivo;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
            rutaArchivo = Path.Combine(Application.persistentDataPath, "datosJuego.json");
            CargarDatos();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GuardarDatos()
    {
        string jsonData = JsonUtility.ToJson(datosJuego);
        File.WriteAllText(rutaArchivo, jsonData);
    }

    public void CargarDatos()
    {
        if (File.Exists(rutaArchivo))
        {
            string jsonData = File.ReadAllText(rutaArchivo);
            datosJuego = JsonUtility.FromJson<DatosJuego>(jsonData);
        }
        else
        {
            datosJuego = new DatosJuego();
        }
    }
}
