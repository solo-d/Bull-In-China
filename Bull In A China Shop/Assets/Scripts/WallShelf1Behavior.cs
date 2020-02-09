using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShelf1 : MonoBehaviour
{

    //find all game objects with the word BigPlate in its name
    //public int BigPlate = 1500
    //find all game objects with the word SmallPlate in its name
    //public int SmallPlate = 500
    //find all game objects with the word Set in its name
    //public int Set = 2500
    //find all game objects with the word TC in its name
    //public int TC = 250
    //find all game objects with the word Saucer in its name
    //public int Saucer = 0


    // Start is called before the first frame update
    void Start()
    {
        //for each object, put into an array. Not sure seperate or a big array
        //9 Objects  
        //On collision, choose a 1 to 4 (inclusive). The result will determine how many objects will be chosen to be broken
        //then once selected, choose a number either 1 to 2 (inclusive) (so boolean here) and apply to each object.
        //if 1 then break object, remove from array, subtract from score, destroy object when new round starts
        //else remain intact (so do nothing) 
    }

    // Update is called once per frame
    void Update()
    {
        // when the round is over, any object that was chosen on collision but got a 2, will be placed back on the shelf for the next round
    }
}
