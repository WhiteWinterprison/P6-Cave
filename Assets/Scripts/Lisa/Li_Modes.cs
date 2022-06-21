//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Implementation of the states from the Mode Manager


//What it do:
// - start the state machine
// - keep the state machine running
// - provide a function to switch the modes
// - handle the communication with the network to update the other user


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

using Hashtable = ExitGames.Client.Photon.Hashtable; //This line need to be on every script that uses the Hashtable!!

public class Li_Modes : MonoBehaviour
{
    #region Variables

    Li_ModeManager currentState;

    public UnityEvent onModeChanged;

    //the setup for a multiplayer boolean
    Hashtable myModeBoolean = new Hashtable() { { "Modes", true} };

    #endregion

    #region First Setup

    private void Awake()
    {
        //create the first "Modes" property
        myModeBoolean["Modes"] = false;
        PhotonNetwork.CurrentRoom.SetCustomProperties(myModeBoolean);
        PhotonNetwork.CurrentRoom.SetCustomProperties(myModeBoolean);

        //register the event
        if (onModeChanged == null)
        {
            onModeChanged = new UnityEvent();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //create the first state the users are in
        currentState = new BuildMode();
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        //call the current state
        currentState = currentState.Process();
    }

    #region Functions for Managing the Modes

    //function for the RoomUIManager function provided for the Switch Button
    public void SwitchModes()
    {
        bool newBool = GetRoomMode();
        if (newBool)
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
    public bool GetRoomMode()
    {
        return (bool)PhotonNetwork.CurrentRoom.CustomProperties["Modes"];
    }

    //function to read the private variable
    public Li_ModeManager GetCurrentState()
    {
        return currentState;
    }

    #endregion
}
