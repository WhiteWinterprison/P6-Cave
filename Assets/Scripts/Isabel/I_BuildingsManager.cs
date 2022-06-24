//---------by Isabel Bartelmus-----------
//You need CaveTable & VrBelt on 2 obj to make this work
//-----------24.06.22-------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class I_BuildingsManager : MonoBehaviour
{
    //Singelton -> We only want 1 Manager
    #region  Singelton
     public static I_BuildingsManager Instance { set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(this.gameObject);

        foreach(GameObject tempObj in GameObject.FindGameObjectsWithTag("VRSocket"))
        {
            VRSockets.Add(tempObj);
        }
        foreach(GameObject tempObj in GameObject.FindGameObjectsWithTag("CaveSocket"))
        {
            CaveSockets.Add(tempObj);
        }
    }
    #endregion

    //------------------Events------------------
     public static event Action OnBuilding_givable;
     public static event Action OnBuilding_placable;

    //------------------Variabels------------------
    [TextArea]
    public String SetupInfo;
    [SerializeField]private List<GameObject> CaveSockets;
    [SerializeField]private List<GameObject> VRSockets; 
    [SerializeField]private List<GameObject> Buildings; 
    [SerializeField]private bool canBePlaced= false;
    [SerializeField]private bool CanBeGiven=false ;



    void Start()
    {
        //Subscribing as a Listener to following events:
        I_CaveTable.OnBuildingGiven += BuildingIsGiven;
        I_VrBelt.OnBuildingPlaced += BuildingIsPlaced;

        // BuildingManager shall assign each socketpair which building will be used
        if (VRSockets.Count != CaveSockets.Count)
        {
            Debug.LogError("Mismatch on socket count between Cave and VR\n Check if Sockets are tagged");
        }

        for (int i = 0; i < VRSockets.Count; i++)
        {
            if(i >= Buildings.Count)
            {   
                Debug.LogWarning("There are not enough buildings in the list of the BuildingsManager!");
                break;
            }
            VRSockets[i].GetComponent<XRSocketInteractor>().startingSelectedInteractable = Buildings[i].GetComponent<XRGrabInteractable>();
            CaveSockets[i].GetComponent<XRSocketInteractor>().startingSelectedInteractable = Buildings[i].GetComponent<XRGrabInteractable>();
        }


    }

   void Update()
   {
        if(canBePlaced == true)
        {
            OnBuilding_placable?.Invoke(); //If the event exist do it
            Debug.Log("BuildingManager: Place It");
        }

        if(CanBeGiven == true)
        {
            OnBuilding_givable?.Invoke();
            Debug.Log("BuildinManager: Given");
        }
   }

   public void spawnBuilding()
   {
    
   }


#region Events
   private void BuildingIsGiven()
   {
        Debug.Log("Building is Ready for VR use");
        canBePlaced = true;
        CanBeGiven = false;
   }


   private void BuildingIsPlaced()
   {
        Debug.Log("Vr User used building, Bulidings can be given out again");
        canBePlaced = false;
        CanBeGiven = true;
   }




  private void OnDisable()
  {
    //unsubscribe to following events if theye are Distroyed:
    I_CaveTable.OnBuildingGiven -= BuildingIsGiven;
    I_VrBelt.OnBuildingPlaced -= BuildingIsPlaced;
  }
  #endregion 

}

