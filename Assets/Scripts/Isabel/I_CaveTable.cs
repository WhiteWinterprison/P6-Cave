//---------by Isabel Bartelmus-----------
//You need CaveTable & BuildignsManager on 2 obj to make this work
//-----------24.06.22-------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class I_CaveTable : MonoBehaviour
{

    //Singelton -> We only want 1 Manager
    #region  Singelton
     public static I_CaveTable Instance { set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(this.gameObject);
    }
    #endregion

    //Event Created by this Instance
    public static event Action OnBuildingGiven;

    //----------Variables-------------
    private bool buildingEnabled = true;

    void Start()
    {
        I_BuildingsManager.OnBuilding_givable += BuildingCanBeGiven;
    }

     private void BuildingCanBeGiven()
    {
        Debug.Log("Building can be used Again");
        buildingEnabled = true;
    }

    public void BuildingWasTouched() //When Building was touched Invoke this funktion
    {
        OnBuildingGiven?.Invoke();
        buildingEnabled =false;
        Debug.Log("Building was given to VR user");
    }

    void OnDisable()
    {
        I_BuildingsManager.OnBuilding_givable -= BuildingCanBeGiven;
    }




}
