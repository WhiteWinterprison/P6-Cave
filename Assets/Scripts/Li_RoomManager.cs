//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Handling the Multiplayer Setup inside the room


//What it do:
// - create the singleton instance
// - register and unregister the scene from the delegate
// - according to the player setup, spawn the correct player prefab


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable; //This line need to be on every script that uses the Hashtable!!

//deriving from MonoBehaviour Callbacks instead of MonoBehaviour for more PUN specific functionality
public class Li_RoomManager : MonoBehaviourPunCallbacks
{
    #region Variables

    [Header("The Names of the possible Player Prefabs")]
    [SerializeField]
    private string defaultName;
    [SerializeField]
    private string caveName;
    [SerializeField]
    private string vrName;

    [Header("The Range for the Spawning Position")]
    [SerializeField]
    private float range = 3.0f;

    //----------------------------------------------------------------//
    //set up the data that needs to be handed over between multiplayer//
    //----------------------------------------------------------------//

    public int myData = (int)PhotonNetwork.CurrentRoom.CustomProperties["Data"];
    Hashtable setInt = new Hashtable();

    #endregion

    #region Singleton Pattern

    public static Li_RoomManager Instance { set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(this.gameObject);
    }

    #endregion

    private void OnEnable()
    {
        //register to delegate
        SceneManager.sceneLoaded += OnSceneLoad;

        //set the first states of the data

        setInt.Add("Data", 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(setInt);
    }

    private void OnDestroy()
    {
        //unregister from delegate
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    #region Spawning the Player

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-range, range), 0.0f, Random.Range(-range, range));

        if (PhotonNetwork.InRoom)
        {
            //Instantiates by NAME, be carefull with spelling
            switch (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetupDetection>().GetPlayerSetup())
            {
                case 1: PhotonNetwork.Instantiate(defaultName, spawnPos, Quaternion.identity); break;
                case 2: PhotonNetwork.Instantiate(caveName, spawnPos, Quaternion.identity); break;
                case 3: PhotonNetwork.Instantiate(vrName, spawnPos, Quaternion.identity); break;
                default: break;
            }
        }
        else
        {
            //Instantiates by NAME, be carefull with spelling
            switch (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetupDetection>().GetPlayerSetup())
            {
                case 1: Instantiate(Resources.Load(defaultName), spawnPos, Quaternion.identity); break;
                case 2: Instantiate(Resources.Load(caveName), spawnPos, Quaternion.identity); break;
                case 3: Instantiate(Resources.Load(vrName), spawnPos, Quaternion.identity); break;
                default: break;
            }
        }
    }

    #endregion
}
