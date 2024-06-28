using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCaido : MonoBehaviour
{
    public float velocidadCaida = 5f;
    public float limiteInferior = -6f; // Ajusta según la posición de tu canasta

    private void Update()
    {
        // Mover el objeto hacia abajo
        transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);

        // Destruir el objeto si pasa el límite inferior
        if (transform.position.y < limiteInferior)
        {
            Destroy(gameObject);
        }
    }
}