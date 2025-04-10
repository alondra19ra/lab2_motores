using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColores : MonoBehaviour
{
    public GameObject Jugador;
    public Color color;
    public void CambiarDeColor()
    {
        Jugador.GetComponent<SpriteRenderer>().color = color;
    }
}


