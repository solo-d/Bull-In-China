using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float CurrentTime = 0f;
    float StartingTime = 120f;
    [SerializeField] Text CountDownText;

    void Start()
    { CurrentTime = StartingTime; }

    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;

        CountDownText.text = CurrentTime.ToString("0");
        if (CurrentTime <= 0)
        { CurrentTime = 0; }
        if (CurrentTime <=9.5) { CountDownText.color = Color.red; }
    }
}