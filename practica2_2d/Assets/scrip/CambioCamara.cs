using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public Camera camara1;
    public Camera camara2;
    public GameObject objetoDeActivacion;

    private bool enZona = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == objetoDeActivacion)
        {
            enZona = true;
            CambiarDisplays();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == objetoDeActivacion)
        {
            enZona = false;
            // Puedes restaurar las cámaras aquí si es necesario
        }
    }

    void CambiarDisplays()
    {
        // Cambia el targetDisplay de la cámara1 a 1 y el de la cámara2 a 0
        camara1.targetDisplay = 1;
        camara2.targetDisplay = 0;
    }
}