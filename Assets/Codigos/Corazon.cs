using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    public float cantidadCuracion = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player jugador = other.GetComponent<Player>();
        if (jugador != null)
        {
            jugador.RecuperarVida(cantidadCuracion);
            Destroy(gameObject);
        }
    }
}
