using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class moviemientoPJ : MonoBehaviour
{
    public float velocidad;
    Rigidbody2D rigidBody;
    private float inputMovement;
    public bool mirandoDerecha= true;
    public float velSalto;
    public LayerMask surfacelayer;
    //estas dos variables es pa arreglar el slato
    public bool enelsuelo;
    BoxCollider2D boxCollider;
    //animacion correr
    public bool correr;
    private Animator animator;

    //Doble salto
    public int dobleS;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator= GetComponent<Animator>();
    }


    bool Comprobarsuelo() {

        RaycastHit2D raycastHit = Physics2D.BoxCast(
                                        boxCollider.bounds.center, //Origen de la caja
                                        new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), //Tamaño
                                        0f, //Ángulo
                                        Vector2.down, //Direccion hacia la que va la caja
                                        0.2f, //Distancia a la que aparece la caja
                                        surfacelayer//Layer mask
                                        );
        return raycastHit.collider != null; //Devuelvo un valor siempre que no sea nulo

    }



    // Update is called once per frame
    void Update()
    {
        ProcessingMovement();
        Salto();
        enelsuelo = Comprobarsuelo();

    }
   private void ProcessingMovement() 
    {
        
        inputMovement = Input.GetAxis("Horizontal");
        correr = inputMovement != 0 ?  true : false ;
        animator.SetBool("correr", correr);
        rigidBody.velocity = new Vector2(inputMovement * velocidad, rigidBody.velocity.y);
        Pjorientacion(inputMovement);
    }

    private void Pjorientacion(float inputMovement)
    {
        if ((mirandoDerecha && inputMovement < 0) || (!mirandoDerecha && inputMovement > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
    private void Salto() { 
        if(Input.GetKeyDown(KeyCode.Space) && enelsuelo)
        {
            rigidBody.AddForce(Vector2.up * velSalto, ForceMode2D.Impulse);
        }
    }

}
