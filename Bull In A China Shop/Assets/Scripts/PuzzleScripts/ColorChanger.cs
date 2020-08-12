using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
//using Wilberforce;

public class ColorChanger : MonoBehaviour
{
    public GameObject Cam;
    public int colorType;
    
    void Start()
    {
        colorType = PlayerPrefs.GetInt("colorType", 0);
    }
    void Update() 
    {
        //PlayerPrefs.GetInt("pickColor");
        //Camera.main.gameObject.GetComponent<Colorblind>().Type = colorType;
    }  

}
