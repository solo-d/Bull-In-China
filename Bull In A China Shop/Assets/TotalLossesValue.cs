using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TotalLossesValue : MonoBehaviour
{

    public Canvas myCanvas;
    public Text totalScoretext;


    private string display = "";



    List<string> addupValues;

    private bool callMe;


    void Start()
    {
        addupValues = new List<string>();

        addupValues.Add("Total Losses Variable");



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
        foreach (string msg in addupValues)
        {
            display = display.ToString() + msg.ToString() + "\n";
        }
        totalScoretext.text = display;
    }

}
