//---------by Isabel Bartelmus-----------
//You need BuildingsManager & VrBelt on 2 obj to make this work
//-----------24.06.22-------------------using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class I_VrBelt : MonoBehaviour
{
    //Singelton -> We only want 1 Manager
    #region  Singelton
     public static I_VrBelt Instance { set; get; }

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
    public static event Action OnBuildingPlaced;

    //----------variables-----------------
    private bool buildEnabled = false;

    void Start()
    {
        
        I_BuildingsManager.OnBuilding_placable += BuildingCanBePlaced;
    }


    private void BuildingCanBePlaced()
    {
        Debug.Log("Buildings Can Be Placed");
        buildEnabled = true;
        //what building will be enabled ?
    }

    public void BuildWasPlaced()
    {
        OnBuildingPlaced?.Invoke();
        buildEnabled = false;
        Debug.Log("Building was placed can be given again");
    }

    void OnDisable()
    {
        I_BuildingsManager.OnBuilding_placable -= BuildingCanBePlaced;
    }
}
