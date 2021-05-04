using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int cowntdownTime;
    public Text cowntdownDisplay;

    private void Start()
    {
        StartCoroutine(cowntdownToStart());
    }
     

    IEnumerator cowntdownToStart ()
    {
        while (cowntdownTime > 0)
        {
            cowntdownDisplay.text = cowntdownTime.ToString();
            yield return new WaitForSeconds(1f);
            cowntdownTime--; 
        }
        cowntdownDisplay.text = "Go!";
       // Player_skin.instance.BeginGame();

            yield return new WaitForSeconds(1f);

        cowntdownDisplay.gameObject.SetActive(false);
    }
}
