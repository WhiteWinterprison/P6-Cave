//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Handling the Player Setup (or implementing the Setup States)


//What it do:
// - activate all available displays
// - check for the setup of the player
// - provides functions to change the setup
// - provides an unity event to invoke when changing the setup
// - spawns/respawns the player whenever necessary


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class Li_PlayerSetup : MonoBehaviour
{
    #region Variables

    //variables for the player Setup

    private int playerSetup;

    public UnityEvent onSetupChanged;

    //the variables and refs for spawning the player

    [Header("The different Camera Prefabs")]
    [SerializeField]
    private GameObject defaultCamera;
    [SerializeField]
    private GameObject caveSetup;
    [SerializeField]
    private GameObject vrSetup;

    [Header("The Names of the possible Player Prefabs")]
    [SerializeField]
    private string defaultName;
    [SerializeField]
    private string caveName;
    [SerializeField]
    private string vrName;

    [Header("The Variables to pass the correct refs to")]
    [SerializeField]
    private string myName;
    [SerializeField]
    private GameObject myPrefab;

    [Header("The Variables for calculating the Positions for the Prefabs to spawn in")]
    [SerializeField]
    private Transform cavePoint;
    [SerializeField]
    private Transform vrPoint;
    [SerializeField]
    private float range = 3.0f;

    //making the user setup possible

    [Header("How many Displays for the CAVE Setup")]
    [SerializeField]
    private int displayCount = 6; //counting starts at 0, so in the code pls add -1 (wanted to make it easier for the person inputting the display count into the inspector, since there are technically 6 screens)

    #endregion

    #region Handleing the Setup States

    private void Awake()
    {
        //activate all available dispalys
        ActivateDisplays();

        //check for the users setup
        /*if (OpenVR.IsHmdPresent() && Display.displays.Length < displayCount - 1) //if there is a HMD present and there are less than 6 screens
        {
            playerSetup = 3; //its the VR setup
        }*/
        else if (Display.displays.Length >= displayCount - 1) //if there is a HMD present but there are also 6 displays
        {
            playerSetup = 2; //its the CAVE setup
        }
        else //or there is nothing special
        {
            playerSetup = 1; //and its the default/desktop setup
        }

        //register the event
        if (onSetupChanged == null)
        {
            onSetupChanged = new UnityEvent();
        }
    }

    #endregion

    #region Functions for the Player Setup

    //function to see which player setup it is supposed to be
    public int GetPlayerSetup()
    {
        return playerSetup;
    }

    //function to call inside the MainMenuManager function for the Switch Button
    public void ChangePlayerSetup()
    {
        switch (playerSetup)
        {
            case 1: playerSetup = 2; break; //switch to the default setup
            case 2: playerSetup = 3; break; //switch to the CAVE setup
            case 3: playerSetup = 1; break; //switch to the VR setup
            default: Debug.Log("Wrong playerSetup loaded"); break;
        }

        onSetupChanged.Invoke();
    }

    //function provided for the event to be able to destroy
    public void DestroyMyPlayer()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if (obj.GetComponent<PhotonView>().IsMine)
                    {
                        Destroy(obj);
                    }
                }
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
            }
        }
    }

    //function to provide the correct variables out of the three choices
    public void PlayerSetupVariables()
    {
        switch (playerSetup)
        {
            case 1: myName = defaultName; myPrefab = defaultCamera; Debug.Log("Setup = default"); break; //switch to the default setup
            case 2: myName = caveName; myPrefab = caveSetup; Debug.Log("Setup = CAVE"); break; //switch to the CAVE setup
            case 3: myName = vrName; myPrefab = vrSetup; Debug.Log("Setup = VR"); break; //switch to the VR setup
            default: Debug.Log("playerSetup set to wrong value"); break;
        }
    }

    //function provided for the event to be able to instantiate
    public void SpawnMyPlayer()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);

        if (PhotonNetwork.InRoom)
        {
            //calculate the correct spawn position
            switch (playerSetup)
            {
                case 1: spawnPos = new Vector3(Random.Range(-range, range), 1.7f, Random.Range(-range, range)); break; //default is spawning in the middle
                case 2: spawnPos = cavePoint.position; break; //CAVE is spawning inside of the CAVE
                case 3: spawnPos = vrPoint.position; break; //VR is spawning opposite of them
                default: Debug.Log("playerSetup wrong value so no spawn position"); break;
            }

            //Instantiates by NAME, be carefull with spelling
            PhotonNetwork.Instantiate(myName, spawnPos, Quaternion.identity);
        }
        else
        {
            //calculate the correct spawn position
            spawnPos = new Vector3(Random.Range(-range, range), 1.7f, Random.Range(-range, range));

            //Instantiates by NAME, be carefull with spelling
            Instantiate(myPrefab, spawnPos, Quaternion.identity);
        }
    }

    #endregion
    
    #region Other needed Functions

    //function to activate all available displays
    private void ActivateDisplays()
    {
        Debug.Log(Display.displays.Length);

        for (int i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();
    }
    
    #endregion
}
