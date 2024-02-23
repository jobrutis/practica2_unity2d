using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class moviemientoPJ : MonoBehaviour
{
    public float velocidad;
    Rigidbody2D rigidBody;
    private float inputMovement;
    public bool mirandoDerecha = true;
    public float velSalto;
    public LayerMask surfacelayer;
    // Estas dos variables son para arreglar el salto
    public bool enelsuelo;
    BoxCollider2D boxCollider;
    // Animación correr
    public bool correr;
    private Animator animator;

    //Animacion salto
    public bool saltando;
    

    // Doble salto
    public int dobleS = 0; // Puedes ajustar el valor según tus necesidades
    private int saltosRealizados = 0;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    bool ComprobarSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
                                        boxCollider.bounds.center,
                                        new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),
                                        0f,
                                        Vector2.down,
                                        0.2f,
                                        surfacelayer
                                    );
        return raycastHit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessingMovement();
        Salto();
        enelsuelo = ComprobarSuelo();
        animator.SetBool("saltando", !enelsuelo);
    }

    private void ProcessingMovement()
    {
        inputMovement = Input.GetAxis("Horizontal");
        correr = inputMovement != 0 ? true : false;
        animator.SetBool("correr", correr);
        rigidBody.velocity = new Vector2(inputMovement * velocidad, rigidBody.velocity.y);
        PjOrientacion(inputMovement);
    }

    private void PjOrientacion(float inputMovement)
    {
        if ((mirandoDerecha && inputMovement < 0) || (!mirandoDerecha && inputMovement > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&(enelsuelo || dobleS < 1))
        {
            
            
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
                rigidBody.AddForce(Vector2.up * velSalto, ForceMode2D.Impulse);
                dobleS++; // Incrementa el número de saltos realizados
                saltando = true;
               
        }

        // Restablecer la cantidad de saltos realizados cuando toca el suelo
        if (enelsuelo)
        {
            
            dobleS = 0;
        }
    }
}