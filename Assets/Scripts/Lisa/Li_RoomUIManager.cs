//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Handling the Room UI behaviour and providing functions for its UI elements


//What it do:
// - sets the beginning state of the UI depending on what kind of player the user is


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using TMPro;

public class Li_RoomUIManager : MonoBehaviour
{
    #region Variables

    [Header("The UIs")]
    [SerializeField]
    private GameObject defaultUI;
    [SerializeField]
    private GameObject caveUI;
    [SerializeField]
    private GameObject vrUI;

    [Header("The Mode Changer Buttons inside of the different UI Prefabs")]
    [SerializeField]
    private TextMeshProUGUI defaultModeTitle;
    [SerializeField]
    private TextMeshProUGUI caveModeTitle;
    [SerializeField]
    private TextMeshProUGUI vrModeTitle;

    private TextMeshProUGUI myTitle;

    #endregion

    #region First State

    private void Awake()
    {
        //just to set the myTitle ref
        myTitle = defaultModeTitle;

        //----------------------------------------//
        //create the starting state of the room UI//
        //----------------------------------------//

        switch (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup())
        {
            case 1: defaultUI.SetActive(true); caveUI.SetActive(false); vrUI.SetActive(false); myTitle = defaultModeTitle; break;
            case 2: caveUI.SetActive(true); defaultUI.SetActive(false); vrUI.SetActive(false); myTitle = caveModeTitle; break;
            case 3: vrUI.SetActive(true); caveUI.SetActive(false); defaultUI.SetActive(false); myTitle = vrModeTitle; break;
            default: break;
        }

        UpdateUIMode();
    }
    
    #endregion

    #region Provided Functions

    //function provided for the Switch Button
    public void SwitchMode()
    {
        //call the function from the Modes to switch the mode
        Li_RoomManager.Instance.GetComponent<Li_Modes>().SwitchModes();
    }

    //function provided for the Leave Button
    public void LeaveRoom()
    {
        //call the function from the Network Manager to leave the room
        Li_NetworkManager.Instance.Interact_BackToMenu();
    }

    public void UpdateUIMode()
    {
        //update the mode text inside of the mode button
        myTitle.text = Li_RoomManager.Instance.GetComponent<Li_Modes>().GetCurrentState().GetModeText();
        Debug.Log("Updated Mode Text");
    }

    //function provided for the Switch Buttons
    public void ChangeSetup()
    {
        //call the function from the Player Setup to change the player setup
        Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().ChangePlayerSetup();

        //set the UI objects according to the player setup
        switch (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup())
        {
            case 1: defaultUI.SetActive(true); caveUI.SetActive(false); vrUI.SetActive(false); myTitle = defaultModeTitle; break;
            case 2: caveUI.SetActive(true); defaultUI.SetActive(false); vrUI.SetActive(false); myTitle = caveModeTitle; break;
            case 3: vrUI.SetActive(true); caveUI.SetActive(false); defaultUI.SetActive(false); myTitle = vrModeTitle; break;
            default: break;
        }

        UpdateUIMode();
    }

    #endregion
}
