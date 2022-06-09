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

//deriving from MonoBehaviour Callbacks instead of MonoBehaviour for more PUN specific functionality
public class RoomManager : MonoBehaviourPunCallbacks
{
    #region Variables

    [Header("The Names of the possible Player Prefabs")]
    [SerializeField]
    private string defaultName;
    [SerializeField]
    private string caveName;
    [SerializeField]
    private string vrName;

    #endregion

    #region Singleton Pattern

    public static RoomManager Instance { set; get; }

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
    }

    private void OnDestroy()
    {
        //unregister from delegate
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    #region Spawning the Player

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-3.0f, 3.0f), 0.0f, Random.Range(-3.0f, 3.0f));

        if (PhotonNetwork.InRoom)
        {
            //Instantiates by NAME, be carefull with spelling
            switch (NetworkManager.Instance.GetComponent<PlayerSetupDetection>().GetPlayerSetup())
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
            switch (NetworkManager.Instance.GetComponent<PlayerSetupDetection>().GetPlayerSetup())
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
