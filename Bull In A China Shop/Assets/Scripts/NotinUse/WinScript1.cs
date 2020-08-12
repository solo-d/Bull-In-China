using UnityEngine;
using System.Linq;

public class WinScript1 : MonoBehaviour
{
    public GameObject WinMenu1; //you fixed it
    public GameObject TimeCheck1;
    public bool checkWin1;
    public GameObject[] vases;
    public int Score1;
    public GameObject youLose1;
    public bool checkLose1;

    void Start()
    {
        checkWin1 = false;
        //Debug.Log(checkWin1);
        vases = GameObject.FindGameObjectsWithTag("Puzzle1");
        //Debug.Log(vases.Length);
    }

    void Update()
    {
        if (checkLose1 != true)

        {
            if (TimeCheck1.GetComponent<CountDownTimer>().CurrentTime == 0)
            {
                checkLose1 = true;
            }

            if (checkLose1 == true)
            {
                noFix1();
            }
            {
                if (checkWin1 != true)
                {
                    if (vases.All(x => x.GetComponent<BonusPiecesScript>().CorrectPosition == true))
                    {
                        Score1 = vases.Length;
                        //Debug.Log("You win2!");
                        checkWin1 = true;
                    }

                    if (checkWin1 == true)
                    {
                        fixedIt1();
                    }

                }

            }

            void fixedIt1()
            {
                bool isActive = WinMenu1.activeSelf;
                WinMenu1.SetActive(!isActive);
                Time.timeScale = (!isActive) ? 0 : 1;
            }
            void noFix1()
            {
                bool isActive3 = youLose1.activeSelf;
                //Debug.Log(youLose1);
                youLose1.SetActive(!isActive3);
            }
        }

    }
}

