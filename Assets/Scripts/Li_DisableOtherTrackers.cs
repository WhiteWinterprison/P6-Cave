//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Disableing the other users cameras to avoid rendering problems


//What it do:
// - check if the player is inside a room
// - searches for all other players than the users
// - disables all the other players cameras


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Photon.Pun;

public class Li_DisableOtherTrackers : MonoBehaviour
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
                    //disable the tracked pose driver (on the head)
                    foreach (TrackedPoseDriver poseDriver in obj.GetComponentsInChildren<TrackedPoseDriver>())
                    {
                        poseDriver.enabled = false;
                    }

                    //disable the XR controllers (on the hands)
                    foreach (XRController controller in obj.GetComponentsInChildren<XRController>())
                    {
                        //disable this component
                    }
                }
            }
        }
    }
}
