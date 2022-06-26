//Lisa Fröhlich Gabra, ER, P6, "HEL: The Human Ecosystem Laboratory"

//Providing all managers as singleton references

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singleton/MasterManager")]
public class MasterManager : SingletonObject<MasterManager>
{
    [SerializeField]
    private NetworkManager _networkManager;
    public static NetworkManager NetworkManager { get { return Instance._networkManager; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void FirstInitialize()
    {
        Debug.Log("This message will output before Awake.");
    }
}
