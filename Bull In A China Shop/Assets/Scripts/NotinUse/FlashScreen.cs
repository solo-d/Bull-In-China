using UnityEngine;
using UnityEngine.UI;  
using System.Collections;

public class FlashScreen : MonoBehaviour
{

    public Image whiteFade;

    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(1.0f);
        fadeIn();

        //blink();
    }

    void fadeIn()
    {
        whiteFade.CrossFadeAlpha(0, 1, false);
    }
}
