using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWallShelf1 : MonoBehaviour
{
    //find game object named SmallPlate
    //public int SmallPlate = 500
    // Start is called before the first frame update
    void Start()
    {
        //on collision, choose a number either 1 to 2(inclusive)(so boolean here)
        //if 1 then break object, subtract from score, destroy object when new round starts
        //else remain intact (so do nothing) 
    }

    // Update is called once per frame
    void Update()
    {
        // when the round is over, if it got a 2 then put the item back on the shelf
    }
}
