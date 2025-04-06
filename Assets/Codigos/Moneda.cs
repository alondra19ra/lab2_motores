using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player jugador = other.GetComponent<Player>();
        if (jugador != null)
        {
            jugador.SumarPuntos(valor);
            Destroy(gameObject);
        }
    }
}
