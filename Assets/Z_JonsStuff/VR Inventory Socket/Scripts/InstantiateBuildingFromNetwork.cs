using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InstantiateBuildingFromNetwork : MonoBehaviour
{
    #region GameObjects
    [Header("Buildings to Spawn")]

    public GameObject buildingToSpawn;
    #endregion

    #region SocketSpawnPositions
    [Header("Spawn Position of Object")]

    public Transform spawnPosition;
    #endregion


    [PunRPC]
    public void GetBuilding()
    {

        // use respective socket Position for appropriate instantiation

        Vector3 positionToSpawn = new Vector3(spawnPosition.position.x,
                                              spawnPosition.position.y,
                                              spawnPosition.position.z);

         BuildingSpawn(positionToSpawn);
    }


    private void BuildingSpawn(Vector3 positionToSpawn)
    {
        //PhotonNetwork.                           .name             
                        Instantiate(buildingToSpawn, positionToSpawn, DefaultRotation());
    }
    private static Quaternion DefaultRotation()
    {
        return Quaternion.identity;
    }

}
