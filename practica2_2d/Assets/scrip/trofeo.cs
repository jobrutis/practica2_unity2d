using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trofeo : MonoBehaviour
{
    public score puntost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("me toco");
        puntost.totalscoreT += 1;
        Destroy(this.gameObject);
    }
}

