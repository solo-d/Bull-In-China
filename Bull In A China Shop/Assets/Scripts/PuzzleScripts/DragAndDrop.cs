using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;
    public static int correctPiece;
    public GameObject[] pieces;
    public string levelTag;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        //if(Input.touchCount > 0)
        {
            levelTag = GameObject.Find("GameManager").GetComponent<WinScript>().ceramic;
            pieces = GameObject.FindGameObjectsWithTag(levelTag);
            //Debug.Log(levelTag);

            //Debug.Log("Drag and Drop - Level Tag:" + levelTag);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero); 
            if (hit.transform.CompareTag(levelTag))
            {
                if (!hit.transform.GetComponent<PiecesScript>().CorrectPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PiecesScript>().Selected = true;
                }
                else
                    return;
            }
                /*else if (hit.transform.CompareTag("Vase"))
                    {
                        if (!hit.transform.GetComponent<PiecesScript>().CorrectPosition)
                        {
                            SelectedPiece = hit.transform.gameObject;
                            SelectedPiece.GetComponent<PiecesScript>().Selected = true;
                        }
                    }*/

        }
        if (Input.GetMouseButtonUp(0)) //when piece is dropped
        //if(Input.touchCount == 0)
        {
            SelectedPiece.GetComponent<PiecesScript>().Selected = false;
            SelectedPiece = null; //no longer select piece
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //snap piece to mouse
            //Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); //snap piece to mouse
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0); //making sure that Z is 0
        }
    }

}