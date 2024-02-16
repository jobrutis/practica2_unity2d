using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverenemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 3f;

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float movement = Mathf.Sin(Time.time * velocidad) * distancia;
        transform.position = new Vector2(startPosition.x + movement, transform.position.y);
    }
}
