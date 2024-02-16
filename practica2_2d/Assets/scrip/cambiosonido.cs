using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiosonido : MonoBehaviour
{
    public AudioClip sonido;
    public GameObject objetoQueDeberiaPasar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == objetoQueDeberiaPasar)
        {
            AudioSource.PlayClipAtPoint(sonido, transform.position);
        }
    }
}
