using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject movimiento;
    public float velocidad;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movimiento.transform.position, velocidad * Time.deltaTime);
    }
    public void SigientePuntoDeControl(GameObject NuevoMovimiento)
    {
        movimiento = NuevoMovimiento;
    }
}
