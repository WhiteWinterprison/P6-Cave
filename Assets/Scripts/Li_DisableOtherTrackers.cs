//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Disableing the other users tracking to avoid tracking problems


//What it do:
// - check if the player is inside a room
// - searches for all other players than the users
// - disables all the other players Tracked Pose Drivers
// - disables all the other players XR Controllers


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
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

                    //disable the xr controllers (inside of the hands)
                    foreach (ActionBasedController controller in obj.GetComponentsInChildren<ActionBasedController>())
                    {
                        controller.enabled = false;
                    }
                }
            }
        }
    }
}
