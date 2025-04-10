using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject movimiento;
    public float velocidad;
    public bool detenido = false;
    private void Update()
    {
        if (!detenido)
        {
            transform.position = Vector2.MoveTowards(transform.position, movimiento.transform.position, velocidad * Time.deltaTime);
        }
    }

    public void DetenerMovimiento()
    {
        detenido = true;
    }

    public void ReanudarMovimiento()
    {
        detenido = false;
    }

    public void CambiarColor(Color nuevoColor)
    {
        GetComponent<SpriteRenderer>().color = nuevoColor;
    }
    public void SiguientePuntoDeControl(GameObject NuevoMovimiento)
    {
        movimiento = NuevoMovimiento;
    }
}
