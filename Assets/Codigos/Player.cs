using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class Player : MonoBehaviour
{
    // Movimiento y físicas
    Rigidbody2D prota;
    float horizontal;
    public float velocidad;
    public float fuerzaSalto;

    // Saltos
    public bool saltar;
    public bool unSalto;
    public bool dosSaltos;

    // Raycast
    RaycastHit2D rayito;
    public LayerMask layer;

    // Vida
    public const int maxVida = 10;
    public float vidas;
    public Scrollbar scrollbar;

    // UI
    public TextMeshProUGUI textoPuntos;
    public GameObject perdiste;
    public GameObject ganaste;
    public Button button;
    public Button boton;

    // Puntos
    public int puntos = 0;

    // Otros
    
    private int colorIndex = 0;
    private Color[] colores = { new Color(0.5f, 0f, 0.5f), new Color(0.4f, 0.8f, 1f), new Color(1f, 1f, 0f) };

    private SpriteRenderer Renderer;

    public InputAction cambiarColorIzquierda;
    public InputAction cambiarColorDerecha;

    #region Unity Functions

    private void Awake()
    {
        
        prota = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();

        cambiarColorIzquierda.performed += CambiarColorIzquierda;
        cambiarColorDerecha.performed += CambiarColorDerecha;

    }

    private void Start()
    {
        TiempoDelJuego(1);
        scrollbar.size = vidas / maxVida;
        textoPuntos.text = "Puntos: " + puntos;
    }

    private void Update()
    {
        // Vida y puntos UI
        scrollbar.size = vidas / maxVida;
        textoPuntos.text = "Puntos: " + puntos;

        if (vidas <= 0)
        {
            perdiste.SetActive(true);
            TiempoDelJuego(0);
        }
    }
    private void FixedUpdate()
    {
        prota.velocity = new Vector2(horizontal * velocidad, prota.velocity.y);
        CheckRaycast();

        if (saltar)
        {
            if (unSalto)
            {
                prota.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
                saltar = false;
            }
            else if (dosSaltos)
            {
                prota.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
                dosSaltos = false;
            }
            saltar = false;
        }
    }

    #endregion

    #region Raycast y Colisiones

    private void CheckRaycast()
    {
        rayito = Physics2D.Raycast(transform.position, Vector2.down, 1.03f, layer);
        if (rayito.collider != null)
        {
            unSalto = true;
            dosSaltos = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            button.interactable = false;
            boton.interactable = false;

            if (Renderer.color != collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                vidas -= 1;
            }
        }

        if (collision.gameObject.CompareTag("Final"))
        {
            ganaste.SetActive(true);
            Eventos.OnVictoria.Invoke();
            TiempoDelJuego(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            button.interactable = true;
            boton.interactable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("moneda"))
        {
            SumarPuntos(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("corazon"))
        {
            RecuperarVida(1);
            Destroy(other.gameObject);
        }
    }

    #endregion

    #region Métodos Públicos

    public void ReadDireccion(InputAction.CallbackContext Context)
    {
        horizontal = Context.ReadValue<float>();
    }

    public void ReadJump(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            unSalto = true;
        }
        if(unSalto || dosSaltos)
        {
            saltar = true;
        }
    }
    private void CambiarColorIzquierda(InputAction.CallbackContext context)
    {
        colorIndex--; 
        if (colorIndex < 0)
        {
            colorIndex = colores.Length - 1;
        }

        if (colorIndex >= 0)
        {
            Renderer.color = colores[colorIndex];
        }
    }

    private void CambiarColorDerecha(InputAction.CallbackContext context)
    {
        colorIndex++; 

        if (colorIndex >= colores.Length)
        {
            colorIndex = 0;
        }

        if (colorIndex >= 0)
        {
            Renderer.color = colores[colorIndex];
        }
    }


    public void TiempoDelJuego(int a)
    {
        Time.timeScale = a;
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntos.text = "Puntos: " + puntos;
    }

    public void RecuperarVida(float cantidad)
    {
        vidas += cantidad;
        if (vidas > maxVida)
            vidas = maxVida;

        scrollbar.size = vidas / maxVida;
        Eventos.OnVidaActualizada.Invoke(vidas);
    }

    #endregion
}

