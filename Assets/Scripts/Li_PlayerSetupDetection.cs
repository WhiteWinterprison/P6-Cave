//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fr�hlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Detection of the users setup plus reaction to and storage of this information


//What it do:
// - check for the setup of the player
// - store the setup as a variable for other scripts to use
// - instantiate the correct camera setup for the main menu scene
// - provides functions to later change the setup


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Li_PlayerSetupDetection : MonoBehaviour
{
    #region Variables

    private int playerSetup = 1; //default is normal camera

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

    #region First Setup

    private void Awake()
    {
        ActivateDisplays();

        if (OpenVR.IsHmdPresent() && displayCount == Display.displays.Length+1) //if there is a HMD present
        {

             playerSetup = 2; //the setup is the CAVE setup
                Debug.Log("Setup = CAVE");

            // if (Display.displays.Length == displayCount - 1) //and there multiple displays
            // {
            //     playerSetup = 2; //the setup is the CAVE setup
            //     Debug.Log("Setup = CAVE");
            // }
            // else
            // {
            //     playerSetup = 3; //or there is only the hmd and it is the VR setup
            //     Debug.Log("Setup = VR");
            // }
        }
        else if(OpenVR.IsHmdPresent() && displayCount != Display.displays.Length+1 )
        {
            playerSetup = 3; //or there is only the hmd and it is the VR setup
            Debug.Log("Setup = VR");
        }
        else
        {
            playerSetup = 1; //or there is only the hmd and it is the VR setup
            Debug.Log("Setup = default");
        }

        switch (playerSetup)
        {
            case 1: Instantiate(defaultCamera); break;
            case 2: Instantiate(caveSetup); break;
            case 3: Instantiate(vRSetup); break;
            default: Debug.Log("There is either the wrong setup or no prefab to spawn"); break;
        }
    }

    private void Start()
    {
    }

    #endregion

    #region Further Changes to Setup

    public int GetPlayerSetup()
    {
        return playerSetup;
    }

    public void ChangePlayerSetup()
    {
        switch (playerSetup)
        {
            case 1: playerSetup++ ; Debug.Log("Player Setup now CAVE"); break; //switch to the HMD setup
            case 2: playerSetup++ ; Debug.Log("Player Setup now VR"); break; //switch to the VR setup
            case 3: playerSetup = 1; Debug.Log("Player Setup now default"); break; //switch to the default setup
            default: break;
        }
    }

    #endregion

    private void ActivateDisplays()
    {
         Debug.Log(Display.displays.Length);

        for (int i=1; i< Display.displays.Length; i++)
            Display.displays[i].Activate();
    }
}
