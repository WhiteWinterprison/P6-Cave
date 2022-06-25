//---------by Isabel Bartelmus-----------
//You need CaveTable & BuildignsManager on 2 obj to make this work
//-----------24.06.22-------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class I_CaveTable : MonoBehaviour
{
    //---------Events By this Script--
    public static event Action OnBuildingGiven;

    //----------Reverences-----------
    public static I_CaveTable Instance { set; get; }
    I_CollisionWithSocket i_socketCollision;

    //----------Variables-------------
    private bool buildingEnabled = true;
    [HideInInspector]public int BuildingNr;

    public bool RunTheFunktion=false;

    //---------Code------------------
    private void Awake()
    {
        //Singelton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(this.gameObject);

        //get components
        i_socketCollision = GetComponentInChildren<I_CollisionWithSocket>(); //get the script in the child on the teleporter
    }
 
    void Start()
    {
        //Subsicrbe to BuildingManager event
        I_BuildingsManager.OnBuilding_givable += BuildingCanBeGiven;
    }

    void Update()
    {
        //for easy debugging ---------Delte LAter!!!----------
        if(RunTheFunktion == true)
        {
            GetBuildingInTeleporter();
        }
    }

    //Which building is in the teleporter ?
    public  void GetBuildingInTeleporter()
    {

        Debug.Log(i_socketCollision.BuildingName);
        if(i_socketCollision.BuildingName == "Building1")
        {
            BuildingNr = 0;
            Debug.Log("Building Nr:" + BuildingNr);
            BuildingWasTouched(0);
        }
        else if(i_socketCollision.BuildingName == "Building2")
        {
            BuildingNr = 1;
            Debug.Log("Building Nr:" + BuildingNr);
            BuildingWasTouched(1);
        }
        else if(i_socketCollision.BuildingName == "Building3")
        {
            BuildingNr = 2;
            Debug.Log("Building Nr:" + BuildingNr);
            BuildingWasTouched(2);
        }
        else
        {
            Debug.LogError("Obj without tag in Teleporter/n check if all buildigns and children are tagged");
        }
    }


    #region Events
     private void BuildingCanBeGiven()
    {
        Debug.Log("Building can be used Again");
        buildingEnabled = true;
    }

    public void BuildingWasTouched(int BuildingNr) //When Building was touched Invoke this funktion
    {
        OnBuildingGiven?.Invoke();
        buildingEnabled =false;
        Debug.Log("Building was given to VR user");
    }

    void OnDisable()
    {
        I_BuildingsManager.OnBuilding_givable -= BuildingCanBeGiven;
    }

    #endregion


}
