using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    public Transform objetivo;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objetivo);
    }
}
