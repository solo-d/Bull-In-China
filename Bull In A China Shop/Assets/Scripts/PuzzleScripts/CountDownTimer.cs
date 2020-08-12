using System;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject timerContainer;
    public float CurrentTime = 0f;
    float StartingTime = 60.0f;
    public bool gamePaused = false; //set to false at start
    public bool sceneReload;
    public bool stopTimer = false;
    private bool enableTimer;

    [SerializeField] Text CountDownText;

    void Start()
    {
        CurrentTime = StartingTime;
        sceneReload = false;
        stopTimer = false;
        bool.TryParse(PlayerPrefs.GetString("enableTimer"), out enableTimer);
       
        startTimer();
    }

    void Update()
    {
        try
        {                       
            if (!stopTimer)
            {
                // if game is not paused or sceneLoad is true, continue counting down timer
                if (!gamePaused && enableTimer)
                {
                    GameObject.Find("TimeLeft").SetActive(true);
                    GameObject.Find("ProgressBar").SetActive(true);
                    GameObject.Find("CountDownTimer").SetActive(true);
                    startTimer();
                }
                else if (!enableTimer)
                {
                    GameObject.Find("TimeLeft").SetActive(false);
                    GameObject.Find("ProgressBar").SetActive(false);
                    GameObject.Find("CountDownTimer").SetActive(false);
                }

                // Set timer text to 0
                CountDownText.text = CurrentTime.ToString("0.0");

                if (CurrentTime <= 0)
                {
                    stopTimer = true;
                    CurrentTime = 0;
                }
                if (CurrentTime <= 10)
                {
                    CountDownText.color = Color.red;
                }
            }
        }
        catch(Exception e) 
        {
    
        }
    }

    public void startTimer()
    {
        CurrentTime -= 1 * Time.deltaTime;
    }
}