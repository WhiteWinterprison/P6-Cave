//Lisa Fröhlich Gabra, ER, P6, "HEL: The Human Ecosystem Laboratory"

//Managing the Multiplayer Network

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

[CreateAssetMenu(menuName = "Singleton/NetworkManager")]
public class NetworkManager : ScriptableObject
{
    #region Variables

    [Header("Necessary Variables")]
    [SerializeField]
    private ByteReference playerCount;
    [SerializeField]
    private ByteReference roomIndex;
    [SerializeField]
    private ByteReference lobbyIndex;
    [SerializeField]
    private ListReference roomNames;

    #endregion
}
