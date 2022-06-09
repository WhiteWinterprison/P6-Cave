//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Handling the Main Menu behaviour and providing functions for its UI elements


//What it do:
// - start the connection to server via server button
// - quit the application via quit button
// - create a room via the create button
// - user feedback for if user is connected to server or not
// - enableing/disableing creating/joining a room depending on connection
// - join an already created room after searching for it
// - show the correct name of the users setup
// - switch via button between the setups


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    #region Variables

    [Header("The button to connect to the server and the text to display")]
    [SerializeField]
    private GameObject serverButton;
    [SerializeField]
    private string connectToServer;
    [SerializeField]
    private string connectedToServer;

    [Header("The button to join a room and its variables")]
    [SerializeField]
    private GameObject joinButton;
    [SerializeField]
    private string noRoom = "";
    private int roomIndex = 0;


    [Header("The button to create a room")]
    [SerializeField]
    private GameObject createButton;

    [Header("The button to siwtch between CAVE and VR")]
    [SerializeField]
    private GameObject switchButton;
    [SerializeField]
    private string cave;
    [SerializeField]
    private string vr;
    [SerializeField]
    private string defaultCamera;

    #endregion

    #region First State

    private void Awake()
    {
        //------------------------------------------//
        //create the starting state of the main menu//
        //------------------------------------------//

        joinButton.SetActive(false);
        joinButton.GetComponentInChildren<TextMeshProUGUI>().text = noRoom;
        createButton.SetActive(false);
        serverButton.GetComponentInChildren<TextMeshProUGUI>().text = connectToServer;
    }

    private void Start()
    {
        switch (NetworkManager.Instance.GetComponent<PlayerSetupDetection>().GetPlayerSetup())
        {
            case 1: switchButton.GetComponentInChildren<TextMeshProUGUI>().text = defaultCamera; break;
            case 2: switchButton.GetComponentInChildren<TextMeshProUGUI>().text = cave; break;
            case 3: switchButton.GetComponentInChildren<TextMeshProUGUI>().text = vr; break;
            default: break;
        }
    }

    #endregion

    #region Dependencies and Functionality without Interactions

    private void Update()
    {
        //--------------------------------------------------------------------------//
        //handle the feedback about server connection and the ability to join a room//
        //--------------------------------------------------------------------------//

        if (NetworkManager.Instance.GetConnectionStatus() && !joinButton.activeSelf)
        {
            joinButton.SetActive(true);
            createButton.SetActive(true);
            serverButton.GetComponentInChildren<TextMeshProUGUI>().text = connectedToServer;
        }
        else if (!NetworkManager.Instance.GetConnectionStatus() && joinButton.activeSelf)
        {
            joinButton.SetActive(false);
            createButton.SetActive(false);
            serverButton.GetComponentInChildren<TextMeshProUGUI>().text = connectToServer;
        }

        /*if (NetworkManager.Instance.roomNames == null && joinButton.GetComponentInChildren<TextMeshProUGUI>().text != noRoom)
        {
            joinButton.GetComponentInChildren<TextMeshProUGUI>().text = noRoom;
            roomIndex = 0;
        }
        else if (NetworkManager.Instance.roomNames != null && joinButton.GetComponentInChildren<TextMeshProUGUI>().text == noRoom)
        {
            joinButton.GetComponentInChildren<TextMeshProUGUI>().text = NetworkManager.Instance.roomNames[roomIndex];
        }*/
    }

    #endregion

    #region Provided Functions

    //function provided for the server button
    public void ConnectToServer()
    {
        Debug.Log("Start connection process...");

        //call the function from the Network Manager to connect to the server
        NetworkManager.Instance.Interact_StartConnectionToServer();
    }

    //function provided for the quit button
    public void QuitApplication()
    {
        Application.Quit();
    }

    //function provided for the create button
    public void CreateRoom()
    {
        Debug.Log("Start creation process...");

        NetworkManager.Instance.Interact_CreateNewRoom();
    }

    //function provided for the join button
    public void JoinRoom()
    {
        NetworkManager.Instance.Interact_JoinRoom(joinButton.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    //function provided for the switching buttons next to the join button
    public void ShowNextRoom(bool right)
    {
        //--------------------------------------------//
        //what to display when which button is clicked//
        //--------------------------------------------//

        if (right) //the right button was clicked
        {
            roomIndex++;
            if (roomIndex < NetworkManager.Instance.roomNames.Count)
            {
                joinButton.GetComponentInChildren<TextMeshProUGUI>().text = NetworkManager.Instance.roomNames[roomIndex];
            }
            else //if the index exceeds the list start from the beginning
            {
                roomIndex = 0;
                joinButton.GetComponentInChildren<TextMeshProUGUI>().text = NetworkManager.Instance.roomNames[roomIndex];
            }
        }
        else //the left button was clicked
        {
            roomIndex--;
            if (roomIndex >= 0)
            {
                joinButton.GetComponentInChildren<TextMeshProUGUI>().text = NetworkManager.Instance.roomNames[roomIndex];
            }
            else //if the index exceeds the list start from the end
            {
                roomIndex = NetworkManager.Instance.roomNames.Count - 1;
                joinButton.GetComponentInChildren<TextMeshProUGUI>().text = NetworkManager.Instance.roomNames[roomIndex];
            }
        }
    }

    public void SwitchPlayer()
    {
        NetworkManager.Instance.GetComponent<PlayerSetupDetection>().ChangePlayerSetup();

        switch (NetworkManager.Instance.GetComponent<PlayerSetupDetection>().GetPlayerSetup())
        {
            case 1: switchButton.GetComponentInChildren<TextMeshProUGUI>().text = defaultCamera; break;
            case 2: switchButton.GetComponentInChildren<TextMeshProUGUI>().text = cave; break;
            case 3: switchButton.GetComponentInChildren<TextMeshProUGUI>().text = vr; break;
            default: break;
        }
    }

    #endregion
}
