using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class score : MonoBehaviour
{
   
   public int totalscore=0;
   public int totalscoreT=0;
   public TMPro.TMP_Text text;
    public TMPro.TMP_Text trofeo;

 
    void Update()
    {
        text.text = " " + totalscore;
        trofeo.text = " " + totalscoreT;
    }
}
