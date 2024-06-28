using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCanasta : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento de la canasta
    public float limiteIzquierdo = -8f; // Límite izquierdo de la pantalla
    public float limiteDerecho = 8f; // Límite derecho de la pantalla

    private void Update()
    {
        // Obtener la entrada horizontal del usuario
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular el desplazamiento
        float desplazamiento = movimientoHorizontal * velocidad * Time.deltaTime;

        // Obtener la posición actual
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posición
        float nuevaPosicionX = Mathf.Clamp(posicionActual.x + desplazamiento, limiteIzquierdo, limiteDerecho);

        // Aplicar el movimiento
        transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
    }
}