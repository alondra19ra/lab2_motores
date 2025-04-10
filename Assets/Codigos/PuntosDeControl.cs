using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeControl : MonoBehaviour
{
    public GameObject NuevoMovimiento;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();

            if (enemigo != null)
            {
                enemigo.SiguientePuntoDeControl(NuevoMovimiento);
            }
        }
    }
}
