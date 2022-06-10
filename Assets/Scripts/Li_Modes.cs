//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Implementation of the states from the Mode Manager


//What it do:
// - start the state machine
// - keep the state machine running
// - provide the function for the button to switch between the two modes


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Li_Modes : MonoBehaviour
{
    Li_ModeManager currentState;

    [Header("The Button to switch between the Modes")]
    [SerializeField]
    private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        //create the first state the users are in
        currentState = new BuildMode(button);
    }

    // Update is called once per frame
    void Update()
    {
        //call the current state
        currentState = currentState.Process();
    }

    //function provided for the button to switch modes
    public void SwitchModes()
    {
        currentState.SwitchClicked();
    }
}
