using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Scrollbar barraDeVida;
    public TextMeshProUGUI textoPuntos;
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    private void OnEnable()
    {
        Eventos.OnPuntosActualizados.AddListener(ActualizarPuntos);
        Eventos.OnVidaActualizada.AddListener(ActualizarVida);
        Eventos.OnVictoria.AddListener(MostrarVictoria);
        Eventos.OnDerrota.AddListener(MostrarDerrota);
    }

    private void OnDisable()
    {
        Eventos.OnPuntosActualizados.RemoveListener(ActualizarPuntos);
        Eventos.OnVidaActualizada.RemoveListener(ActualizarVida);
        Eventos.OnVictoria.RemoveListener(MostrarVictoria);
        Eventos.OnDerrota.RemoveListener(MostrarDerrota);
    }

    void ActualizarPuntos(int puntos)
    {
        textoPuntos.text = "Puntos: " + puntos;
    }

    void ActualizarVida(float vida)
    {
        barraDeVida.size = vida / Player.maxVida;
    }

    void MostrarVictoria()
    {
        panelVictoria.SetActive(true);
    }

    void MostrarDerrota()
    {
        panelDerrota.SetActive(true);
    }
}
