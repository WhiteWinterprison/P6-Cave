//Isabel //based on script from multiplayer tracker people
//code for tracking obj & Player in Multiplayer Photon

using UnityEngine;
using Photon.Pun;
using Valve.VR;

public class I_objTracker : MonoBehaviour
{
   private PhotonView photonView;
   private void Start()
   {
       photonView = GetComponent<PhotonView>();

       if(PhotonNetwork.InRoom && !photonView.IsMine)
       {
           //access tracked_obj and disavel it when its not the players view
           GetComponent<SteamVR_TrackedObject>().enabled =false;
       }
   }
}
