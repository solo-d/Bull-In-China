﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTable : MonoBehaviour
{
    //find all game objects with the word Kettle in its name
    //public int Kettle = 1000
    //find all game objects with the word Stack in its name
    //public int Stack = 1500
    //find all game objects with the word Set in its name
    //public int Vase = 5000
    // Start is called before the first frame update
    void Start()
    {
        //for each object, put into an array. Not sure seperate or a big array  
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