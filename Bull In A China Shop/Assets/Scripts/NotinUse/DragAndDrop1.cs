using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DragAndDrop1 : MonoBehaviour
{
    public GameObject SelectedPiece1;
    public static int correctPiece1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle1"))
            {
                if (!hit.transform.GetComponent<BonusPiecesScript>().CorrectPosition)
                {
                    SelectedPiece1 = hit.transform.gameObject;
                    SelectedPiece1.GetComponent<BonusPiecesScript>().Selected = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0)) //when piece is dropped
        {
            SelectedPiece1.GetComponent<BonusPiecesScript>().Selected = false;  
            SelectedPiece1 = null; //no longer select piece
        }
        if (SelectedPiece1 != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //snap piece to mouse
            SelectedPiece1.transform.position = new Vector3(MousePoint.x,MousePoint.y,0); //making sure that Z is 0
        }
    }
}
