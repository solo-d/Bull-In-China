﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShelf : MonoBehaviour
{
    //find all game objects with the word BigPlate in its name
    //public int BigPlate = 1500
    //find all game objects with the word Vase in its name
    //public int Vase = 5000
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
        //On collision, take n = (array.length/2) - 1 then choose between 1 - n (inclusive) and The result will determine how many objects will be chosen to be broken
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