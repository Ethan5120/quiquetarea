using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
public float pSpeed = 10f, jForce, playerMaxHP = 6f;
    [SerializeField]protected bool pJump = true;
    Rigidbody2D rb;
    private bool m_FacingRight = true;
    Rigidbody2D cuerpoPlayer;
    int saltos;
    public TextMeshProUGUI textoScore;
    public Transform respawnPoint;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xMove * pSpeed, rb.velocity.y);


        if (xMove > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (xMove < 0 && m_FacingRight)
        {
            Flip();
        }




        if (Input.GetKeyDown(KeyCode.Space) && pJump == true)
        {
            rb.AddForce(Vector2.up * jForce, ForceMode2D.Impulse);
            pJump = false;
        }
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
{
saltos = 2;//Recargo mis saltos al tocar el suelo
}
//Al chocar con el enemigo, hago respawn al punto indicado
if (collision.gameObject.CompareTag("enemy"))
{//Reaparecemos en el punto de respawn definido en Unity
transform.position = respawnPoint.position;
}
        if (collision.gameObject.CompareTag("Ground"))
        {
            pJump = true;
        
        }
    }

    
//Estas variables pueden ir en donde sea con que no esten
// dentro de un bloque de codigo, solo estan dentro de tu
// script
public int puntos;//Esto es una variable global tambien
void OnTriggerEnter2D(Collider2D collision)
{
if (collision.gameObject.CompareTag("point"))
{
puntos += 1;
//Al combinar dos textos se le llama concatenaci n�
textoScore.text = "Puntos: " + puntos.ToString();
Destroy(collision.gameObject);//Destruimos el punto
}
}
}
