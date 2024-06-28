using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    public GameObject[] objetosPrefab; // Array de prefabs de objetos a generar
    public float intervaloGeneracion = 2f;
    public float rangoX = 8f; // Rango horizontal para la generación de objetos
    public float alturaGeneracion = 6f; // Altura desde donde se generan los objetos

    private void Start()
    {
        // Iniciar la generación de objetos
        InvokeRepeating("GenerarObjeto", 0f, intervaloGeneracion);
    }

    private void GenerarObjeto()
    {
        // Seleccionar un objeto aleatorio del array
        GameObject objetoSeleccionado = objetosPrefab[Random.Range(0, objetosPrefab.Length)];

        // Generar una posición aleatoria en X
        float posicionX = Random.Range(-rangoX, rangoX);

        // Crear el objeto en la posición calculada
        Vector3 posicionGeneracion = new Vector3(posicionX, alturaGeneracion, 0f);
        Instantiate(objetoSeleccionado, posicionGeneracion, Quaternion.identity);
    }
}
