//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Disableing the other users cameras to avoid rendering problems


//What it do:
// - 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Li_DisableingOtherCameras : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (!obj.GetComponent<PhotonView>().IsMine)
                {
                    foreach (Camera cam in obj.GetComponentsInChildren<Camera>())
                    {
                        cam.enabled = false;
                    }
                }
            }
        }
    }
}
