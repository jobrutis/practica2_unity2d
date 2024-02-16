using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class puntaje : MonoBehaviour
{
    private float puntuacion;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion += Time.deltaTime;
        textMesh.text = puntuacion.ToString("0");
    }
}
