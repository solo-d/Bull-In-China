using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    //public GameObject ResumeButton;
    
    public GameObject CountDownTimer;
    public GameObject MainCamera;
    public void openMenu()
    
    {
        if (PauseMenu != null) //if menu is open
        {
            bool isActive = PauseMenu.activeSelf;
            PauseMenu.SetActive(!isActive);
            Time.timeScale = (!isActive) ? 0 : 1;
            MainCamera.GetComponent<DragAndDrop>().enabled = false;         
        }
    }

    public void resume()
    {
        openMenu();
        MainCamera.GetComponent<DragAndDrop>().enabled = true;
    }


}



/*if (ResumeButton != null)
        {
            for (int i = 0; i<puzzle.Length; i++)
            {
                puzzle[i].SetActive(true);
            }

            bool isActive = PauseMenu.activeSelf;
PauseMenu.SetActive(isActive);
            Time.timeScale = (isActive)? 1 : 0;
        }*/