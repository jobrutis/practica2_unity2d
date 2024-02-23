using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip sonidoSalto; // El sonido que se reproducirá al saltar
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Se requiere un componente AudioSource en el mismo GameObject.");
        }
    }

    void Update()
    {
        if (EstaSaltando() && !audioSource.isPlaying)
        {
            ReproducirSonido();
        }
    }

    bool EstaSaltando()
    {
        // Puedes ajustar esta lógica dependiendo de cómo detectes el salto en tu juego.
        // Por ejemplo, si estás utilizando Input.GetKeyDown para saltar, puedes modificar
        // la lógica en consecuencia.
        return Input.GetKeyDown(KeyCode.Space);
    }

    void ReproducirSonido()
    {
        if (sonidoSalto != null)
        {
            audioSource.PlayOneShot(sonidoSalto);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un sonido de salto en el inspector.");
        }
    }
}