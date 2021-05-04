using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public float StartTime = 153 ;
    public Text textBox;
    private bool finished = false ;
    

    void Start()
    {
        textBox.text = StartTime.ToString();
    }

    void Update()
    {
        if (!finished)
        {
        StartTime -= Time.deltaTime;
        textBox.text = Mathf.Round(StartTime).ToString();
        }

       if (StartTime<=0)
       {
           finished = true;
           StartTime = 0;
           textBox.text = "Game Over : "  + Mathf.Round(StartTime).ToString() ;
           Application.LoadLevel(Application.LoadLevel);
       }
    }

}
