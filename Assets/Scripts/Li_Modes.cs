//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Implementation of the states from the Mode Manager


//What it do:
// - 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Li_Modes : MonoBehaviour
{
    Li_ModeManager currentState;

    // Start is called before the first frame update
    void Start()
    {
        //create the first state the users are in
        currentState = new BuildMode();
    }

    // Update is called once per frame
    void Update()
    {
        //call the current state
        currentState = currentState.Process();
    }
}
