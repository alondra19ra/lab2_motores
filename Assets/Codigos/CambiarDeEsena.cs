using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarDeEsena : MonoBehaviour
{
    public void CambiarEsena(string Juego)
    {
        SceneManager.LoadScene(Juego);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
