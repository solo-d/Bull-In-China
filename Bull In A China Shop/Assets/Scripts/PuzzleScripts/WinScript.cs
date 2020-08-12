using UnityEngine;
using System.Linq;
using System;
using System.Collections;

public class WinScript : MonoBehaviour
{
    public GameObject WinMenu; //you fixed it
    public GameObject BonusBut; //bonus round button
    public GameObject NextBut; //tryagain button
    public GameObject TimeCheck;
    public GameObject MainCamera;
    public bool checkWin;
    public GameObject[] levelObject;
    public string[] orgLevel = { "Plate", "Vase", "Mug", "Bowl" };
    public static string[] level;
    public string[] orgOutlineArray = { "O-Plate", "O-Vase", "O-Mug", "O-Bowl" };
    public static string[] outlineArray;
    public string nameLevel;
    public int levelpicker;
    public int Score;
    public GameObject youLose;
    public bool checkLose;
    public string ceramic;
    public string outline;
    public static int round = 1; //keep track on how many wins
    public bool reloaded { get{ return _reloaded; } set{ _reloaded = value; } }
    private static bool _reloaded = false;
    /// <summary>
    /// At the start of the game we want to pick a random level, and use that level as the
    /// tag to find all objects of that ceramic and make it active
    ///
    ///
    /// all objects must be active prior to the logic. If after, then it cannot find objects
    /// with the corresponding tag. It will show up as 0 or null.
    ///
    /// Next level button -> remove last level played. store the variable in Game Manager
    /// from previous level (if any) and compare and ignore.
    /// 
    /// </summary>
    void Start()
    {
        if (!GameManager.sceneReloaded)
        {
            round = 1;
            level = new string[4] { "Plate", "Vase", "Mug", "Bowl" };
            outlineArray= new string[4] { "O-Plate", "O-Vase", "O-Mug", "O-Bowl" }; 
            reloaded = false;
        }
        
        LoadLevel();

        //check last loaded tag from previous level from GameManager, if any
        //then compare tags. if null then ignore.

        //get same number (level) and match it to the location of the string
        // set it to active
    }

    public void LoadLevel()
    {
        // If user completes first round remove round piece from list and pick new piece


        checkWin = false;
        checkLose = false;

        if (round == 3) //in bonus round
        {
            ceramic = "Bowl";
            outline = "O-Bowl";
        }
        else
        {
            UnityEngine.Random.InitState((int)DateTime.UtcNow.Ticks);            

            levelpicker = UnityEngine.Random.Range(0, level.Length - 1); //generate number between 0 and 3 inclusive
            ceramic = level[levelpicker]; //stores string name - vase
            outline = outlineArray[levelpicker];            
        }

        levelObject = GameObject.FindGameObjectsWithTag(ceramic);

        //Debug.Log(levelObject);
        //Debug.Log("Level Tag:" + ceramic); //string name returned
        //Debug.Log("Outline: " + outline);

        for (int i = 0; i <= orgLevel.Length - 1; i++) //then set the objects with the tag to become Active as it starts as hidden
        {
            if (ceramic != orgLevel[i]) //vase is not equal itself (aka 1)
            {
                var gameObjectArray = GameObject.FindGameObjectsWithTag(orgLevel[i]); //get other ceramics into an array

                foreach (GameObject _gameObject in gameObjectArray)
                {
                    _gameObject.SetActive(false); //to turn off in the hierarchy
                }
            }
        }

        for (int i = 0; i <= orgOutlineArray.Length - 1; i++)
        {
            if (outline != orgOutlineArray[i])
            {
                var gameObjectArray = GameObject.FindGameObjectsWithTag(orgOutlineArray[i]);

                foreach (GameObject _gameObject in gameObjectArray)
                {
                    _gameObject.SetActive(false);
                }
            }
        }

        level = level.Where(x => x != level[levelpicker]).ToArray();
        outlineArray = outlineArray.Where(x => x != outlineArray[levelpicker]).ToArray();
    } 
    /*
     *void checkScore(gameLevel)
     * if (x.All(y => y.GetComponent<PiecesScript>().CorrectPosition == true)) 
                {
                    x = gameLevel; //whatever the string is according to the buildindex
                    Score = y.Length;
                    checkWin = true;
                }
     * 
     */


    void Update()
    {
        if (checkLose != true)
        {
            if (TimeCheck.GetComponent<CountDownTimer>().CurrentTime == 0)
            {
                checkLose = true;
            }

            if (checkLose == true)
            {
                noFix();
            }
        
            if (checkWin != true)
            {
                if (levelObject.All(x => x.GetComponent<PiecesScript>().CorrectPosition == true)) //if levelObject is correct
                {
                    Score = levelObject.Length;
                    Debug.Log("You win!");
                    checkWin = true;
                }

                if (checkWin == true)
                {
                    GameObject.Find("PauseButton").SetActive(false);
                    StartCoroutine(WaitSeconds(0.5f));
                }
            }        
        }
    }

    //This is a coroutine that moves the bull
    IEnumerator WaitSeconds(float timeToWait)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeToWait);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
        fixedIt();
    }

    void fixedIt()
    {
        bool isActive = WinMenu.activeSelf;
        WinMenu.SetActive(!isActive);
        Time.timeScale = (!isActive) ? 0 : 1;

        if (round == 1) //Round 1 - Show NextLevel Button instead of Try Again Button
        {
            round++; //if you win, add 1 to the scenetracker variable
            //Show next level button
            bool isActive2 = NextBut.activeSelf;
            NextBut.SetActive(!isActive2);
        }
        else if (round == 2 && TimeCheck.GetComponent<CountDownTimer>().CurrentTime >= 39.5) //Round 2 - Bonus Button, Title Screen
        {
            round++; // int becomes 3
            bool isActive1 = BonusBut.activeSelf;
            BonusBut.SetActive(!isActive1);
        }

        else if (round == 3) //bonus round
        {
            //disable try again button
        }
      
        /*  else if (levelpicker == 3) //if currently on Bowl round, only show the try again and home buttons
        {
            bool isActive2 = TryBut.activeSelf;
            TryBut.SetActive(!isActive2);
        }
        else
        {
            bool isActive2 = TryBut.activeSelf;
            TryBut.SetActive(!isActive2);
        }
       */
    }

    void noFix()
    {
        bool isActive3 = youLose.activeSelf;
        Debug.Log(youLose);
        MainCamera.GetComponent<DragAndDrop>().enabled = false;
        youLose.SetActive(!isActive3);       
    }

}