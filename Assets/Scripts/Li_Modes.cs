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
using Photon.Pun;

using Hashtable = ExitGames.Client.Photon.Hashtable; //This line need to be on every script that uses the Hashtable!!

public class Li_Modes : MonoBehaviour
{
    Li_ModeManager currentState;

    [Header("The Button to switch between the Modes")]
    [SerializeField]
    private GameObject button;

    //the setup for a multiplayer boolean
    Hashtable myModeBoolean = new Hashtable() { { "Modes", true} };

    private void Awake()
    {
        //create the first "Modes" property
        PhotonNetwork.CurrentRoom.SetCustomProperties(myModeBoolean);
    }

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
        bool newBool = false;
        if (GetRoomMode(newBool))
        {
            newBool = false;
        }
        else
        {
            newBool = true;
        }

        myModeBoolean["Modes"] = newBool;
        PhotonNetwork.CurrentRoom.SetCustomProperties(myModeBoolean);
    }

    //function to get the custom property of the mode boolean
    public bool GetRoomMode(bool myBool)
    {
        return myBool = (bool)PhotonNetwork.CurrentRoom.CustomProperties["Modes"];
    }

    //function to read the private variable
    public Li_ModeManager GetCurrentState()
    {
        return currentState;
    }
}
