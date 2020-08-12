using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Wilberforce;
//using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool sceneLoad;
    public static bool sceneReloaded;
    public GameObject timer;
    //public bool checkTimer;
    public GameObject timeButOn;
    public GameObject timeButOff;
    public GameObject difficulty;
    public GameObject tapHold;
    public bool tapControl;
    public GameObject vibration;
    public bool vibControl;
    public GameObject vibButOn;
    public GameObject vibButOff;
    public GameObject Sound;
    public bool soundControl;
    public GameObject soundButOn;
    public GameObject soundButOff;

    //public bool colorAssist { get; set; }
    public bool timerOff { get; set; }
    public int colorType { get; set; }
    public int difficultyMode { get; set; }
    public bool soundOn { get; set; }
    //public bool vibOn { get; set; }



    void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        sceneLoad = false;
        timerOff = false;
        difficultyMode = 2; //1 is Easy; 2 is Normal; 3 is Hard
        tapControl = false; // true is hold
        vibControl = false;
    }

    public void TimerStatus() 
    {
        PlayerPrefs.SetString("enableTimer", timerOff.ToString());
    } 

    public void DifficultySetting(int difficultyMode)
    {
        if (difficultyMode == 1) //easy with 0.5 threshold
        {
            PlayerPrefs.SetFloat("threshold", 0.5f);
            Debug.Log("Difficulty Mode: Easy");
        }
        else if (difficultyMode == 3) //hard with 0.1f threshold
        {
            PlayerPrefs.SetFloat("threshold", 0.1f);
            Debug.Log("Difficulty Mode: Hard");
        }
        else //normal with 0.3f threshold
        {
            PlayerPrefs.SetFloat("threshold", 0.3f);
            Debug.Log("Difficult Mode: Normal");
        }
    }

    public void ColorSetting()
    {
        PlayerPrefs.SetInt("colorType", colorType);
        //GameObject.FindGameObjectsWithTag("MainCamera").ToList().ForEach(y=>y.GetComponent<Colorblind>().Type = colorType);

        //Camera.main.gameObject.GetComponent<Colorblind>().Type = colorType;        
    }

    public void VolumeControl()
    {
        PlayerPrefs.SetString("enableSound", soundControl.ToString());
    }

    public void VibrationControl(bool vibControl)
    {
        PlayerPrefs.SetString("enableVib", vibControl.ToString());
    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        sceneReloaded = false;
    }

    public void LoadCurrentScene()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
        //Debug.Log("Scene has been reloaded");
        sceneLoad = true;
        sceneReloaded = true;
        // TODO: if we decided to add more rounds and only want to display each piece once we will need to fix the level picker logic
        GameObject.Find("GameManager").GetComponent<WinScript>().reloaded = true;
        //Debug.Log(sceneLoad);
        Start();
    }
}