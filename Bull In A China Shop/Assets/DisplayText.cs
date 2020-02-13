using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{

    public Canvas myCanvas;
    public Text lossesText;

    private string display = "";

    List<string> chinaDestroyed;

    private bool callMe;


    void Start()
    {
        chinaDestroyed = new List<string>();

        chinaDestroyed.Add("Big Plates Variable");
        chinaDestroyed.Add("Bowls Variable ");
        chinaDestroyed.Add("Sets of Plates Variable ");
        chinaDestroyed.Add("Small Plates Variable ");
        chinaDestroyed.Add("Tea Cups Variable ");
        chinaDestroyed.Add("Tea Kettles Variable ");
        chinaDestroyed.Add("Vases Variable ");
      
        callMe = true;

    }

    void Update()
    {
        if (callMe)
        {
            AddText();
            callMe = false;
        }
    }

    void AddText()
    {
        foreach (string msg in chinaDestroyed)
        {
            display = display.ToString() + msg.ToString() + "\n";
        }
        lossesText.text = display;
    }
}