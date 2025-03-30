using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarDeEsena : MonoBehaviour
{
    public void CambiarEsena(string Name)
    {
        SceneManager.LoadScene(Name);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
