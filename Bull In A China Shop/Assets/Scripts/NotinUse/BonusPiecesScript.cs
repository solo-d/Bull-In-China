using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusPiecesScript : MonoBehaviour
{
    private Vector3 RandomRight; //randomize pieces on the right side
    public bool CorrectPosition;
    public bool Selected;
    public GameObject WinMenu; //you fixed it menu
   
    void Start()
    {
        RandomRight = transform.position;
        transform.position = new Vector3(Random.Range(4f, 7), Random.Range(4f, -4)); //randomize pieces on the right side
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,RandomRight) < 0.1f) //threshold before snapping
        {
            if (!Selected) //but this number keeps increasing because it is no longer selected
            {
                transform.position = RandomRight; //if puzzle is placed correctly
                Debug.Log("Position is correct");
                CorrectPosition = true; //set this to true
            }
        }
    }
}