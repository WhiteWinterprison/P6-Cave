// - - - - - - - - - - - - - - - - - - - - - - - - - - -
// initialization part is important. 
// checks for tag "CaveUser" & "VRUser" are important
// - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FollowMyPlayer : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    private float distance = 10.0f;
    [SerializeField]
    private float height = 5.0f;
    [SerializeField]
    private float heightDamp = 2.0f;
    [SerializeField]
    private float rotationDamp = 3.0f;

//the player character the camera should follow
    private GameObject player;

// needs photonview component from respective user
    public PhotonView photonView;

    
    void Start()
    {
// - - - - - - - - - - - - - - - - - -
//initialization for VR user
// - - - - - - - - - - - - - - - - - -
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("VRUser"))
        {
            if (obj.GetComponent<PhotonView>().IsMine)
            {
                player = obj;
                Debug.Log("Player for following found");
            }
        }
// - - - - - - - - - - - - - - - - - -
// initialization for Cave user 
// - - - - - - - - - - - - - - - - - -
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("CaveUser"))
        {
            if (obj.GetComponent<PhotonView>().IsMine)
            {
                player = obj;
                Debug.Log("Player for following found");
            }
        }
// - - - - - - - - - - - - - - - - - -

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MainCamera"))
        {
            if (!obj.GetComponent<PhotonView>().IsMine)
            {
                obj.GetComponent<Camera>().enabled = false;
                Debug.Log("Eradicating Cameras");
            }
        }
    }

    void LateUpdate()
    {
//------------------------------------------------------------//
//check for if the camera is able to follow the correct object//
//------------------------------------------------------------//

//only allow control over this player character if it's users view
        if (PhotonNetwork.InRoom && !photonView.IsMine) return;

//check for player character and don't go on if there is none
        if (!player) return;

//---------------------------------//
//calculate current rotation angles//
//---------------------------------//

        float wantedRotationAngle = player.GetComponent<Transform>().eulerAngles.y;
        float wantedHeight = player.GetComponent<Transform>().position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

// Damping
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamp * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamp * Time.deltaTime);

//turn the angle into rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

//---------------------------------------//
//set position and rotation of the camera//
//---------------------------------------//

//position in x-z plane
        transform.position = player.GetComponent<Transform>().position;
        transform.position -= currentRotation * Vector3.forward * distance;

//height
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

//always look at player
        transform.LookAt(player.GetComponent<Transform>());
    }
}
