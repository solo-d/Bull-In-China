﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text time;
    public int total_time = 120;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (total_time >= 0)
        {
            time.GetComponent<Text>().text = "Time:" + total_time.ToString();
            yield return new WaitForSeconds(1);
            total_time--;
        }
        GameManager.Instance.LoadTheNextScene();
    }
}