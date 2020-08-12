using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public float current;
    public Image mask;


    void Start()
    {
        current = maximum;
    }

    void Update()
    {
        //decrease current by 1 per delta time
        if (current > 0)
        {
            current -= Time.deltaTime; //decrease as time progresses
            mask.fillAmount = current / maximum; 
        } else
        {
            //when zero. stop the script.
        }
        //GetCurrentFill();
    }

  /*  void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

    }
    */
}
