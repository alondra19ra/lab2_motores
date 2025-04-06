using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos : MonoBehaviour
{
    public static UnityEvent<int> OnPuntosActualizados = new UnityEvent<int>();
    public static UnityEvent<float> OnVidaActualizada = new UnityEvent<float>();
    public static UnityEvent OnVictoria = new UnityEvent();
    public static UnityEvent OnDerrota = new UnityEvent();
}
