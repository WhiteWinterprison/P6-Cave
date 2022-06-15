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
using Photon.Pun;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable; //This line need to be on every script that uses the Hashtable!!


public class Li_RoomUIManager : MonoBehaviour
{
    #region Variables

    [Header("The Canvas")]
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private string playerTag;
    private GameObject player;

    [Header("The Panels to test the Player Setup Change")]
    [SerializeField]
    private GameObject defaultPanel;
    [SerializeField]
    private GameObject cavePanel;
    [SerializeField]
    private GameObject vrPanel;

    #endregion

    #region First State

    private void Awake()
    {
        defaultPanel.SetActive(false);
        cavePanel.SetActive(false);
        vrPanel.SetActive(false);
    }

    private void Start()
    {
        //assign this users player to the player ref
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(playerTag))
        {
            if (obj.GetComponent<PhotonView>().IsMine) player = obj;
        }

        //set the panels according to the player setup
        //in case of VR setup: correct the canvas so it fits to VR
        switch (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetupDetection>().GetPlayerSetup())
        {
            case 1: defaultPanel.SetActive(true); break;
            case 2: cavePanel.SetActive(true); break;
            case 3: vrPanel.SetActive(true); GetComponent<Li_ResizeCanvasForVR>().ResizeCanvas(canvas, player); break;
            default: break;
        }
    }

    #endregion
}
