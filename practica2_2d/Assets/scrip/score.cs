using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class score : MonoBehaviour
{
   
   public int totalscore;
   public int totalscoreT;
    public TMP_Text text;
    public TMP_Text trofeo;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ""+totalscore;
        trofeo.text = "" + totalscoreT;
    }
}
