//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Handling the Room UI behaviour and providing functions for its UI elements


//What it do:
// - 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Li_RoomUIManager : MonoBehaviour
{
    #region Variables

    [Header("The panels to test the player setup change")]
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
        switch (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetupDetection>().GetPlayerSetup())
        {
            case 1: defaultPanel.SetActive(true); break;
            case 2: cavePanel.SetActive(true); break;
            case 3: vrPanel.SetActive(true); break;
            default: break;
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
