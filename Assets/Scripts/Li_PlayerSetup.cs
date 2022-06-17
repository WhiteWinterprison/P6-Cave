//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Implementation of the states from the SetupStates


//What it do:
// - activate all available displays
// - check for the setup of the player
// - provides functions to change the setup


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Li_PlayerSetup : MonoBehaviour
{
    #region Variables

    Li_SetupStates currentState; //ref to the current player setup state

    private int playerSetup; //default is normal camera

    [Header("The different Camera Prefabs")]
    [SerializeField]
    private GameObject defaultCamera;
    [SerializeField]
    private GameObject caveSetup;
    [SerializeField]
    private GameObject vRSetup;

    [Header("How many Displays for the CAVE Setup")]
    [SerializeField]
    private int displayCount = 6;

    #endregion

    #region Handleing the Setup States

    private void Awake()
    {
        ActivateDisplays(); //activate all available dispalys

        if (OpenVR.IsHmdPresent()) //if there is a HMD present
        {
            playerSetup = 3; //its the VR setup
        }
        else if (Display.displays.Length == displayCount - 1) //if there are multiple displays
        {
            playerSetup = 2; //its the CAVE setup
        }
        else //or there is nothing special
        {
            playerSetup = 1; //and its the default/desktop setup
        }
    }

    private void Start()
    {
        switch (playerSetup)
        {
            case 1: currentState = new DefaultState(); Debug.Log("Setup = default"); break; //switch to the default setup
            case 2: currentState = new CaveState(); Debug.Log("Setup = CAVE"); break; //switch to the CAVE setup
            case 3: currentState = new VrState(); Debug.Log("Setup = VR"); break; //switch to the VR setup
            default: Debug.Log("playerSetup set to wrong value"); break;
        }
    }

    #endregion

    #region Functions to change Player Setup

    //function to activate all available displays
    void ActivateDisplays()
    {
        Debug.Log(Display.displays.Length);

        for (int i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();
    }

    //function to see which player setup it is supposed to be
    public int GetPlayerSetup()
    {
        return playerSetup;
    }

    //function to switch between the player setups
    public void ChangePlayerSetup()
    {
        switch (playerSetup)
        {
            case 1: playerSetup = 2; Debug.Log("Player Setup now CAVE"); break; //switch to the default setup
            case 2: playerSetup = 3; Debug.Log("Player Setup now VR"); break; //switch to the CAVE setup
            case 3: playerSetup = 1; Debug.Log("Player Setup now default"); break; //switch to the VR setup
            default: Debug.Log("Wrong playerSetup"); break;
        }
    }

    #endregion
}
