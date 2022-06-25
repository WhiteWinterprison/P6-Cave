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
    [SerializeField] public static I_VrBelt Instance { set; get; }

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
    [SerializeField]private List<GameObject> vrSockets; 
    //private bool buildEnabled = false;
    public IntVariable BuildingNr;

    //----------Rev---------------------

    void Start()
    {
        //Subscribe to BuildingManager event
        I_BuildingsManager.OnBuilding_placable += BuildingCanBePlaced;
    }

    //Instatiate obj on right Socket
    private void InstantateObjOnSocket(int i)
    {
        //dependign on what int we have get differnt transform to Instantiate the obj
        vrSockets[i].GetComponent<Transform>();

        Quaternion rotation = vrSockets[i].GetComponent<Transform>().rotation;
        Vector3 position = vrSockets[i].GetComponent<Transform>().position;

        //Insantiate the right obj
        
        
    }

    #region Events 
    private void BuildingCanBePlaced()
    {
        Debug.Log("Buildings Can Be Placed");
       // buildEnabled = true;
        //what building will be enabled ?
    }

    public void BuildWasPlaced()
    {
        OnBuildingPlaced?.Invoke();
       // buildEnabled = false;
        Debug.Log("Building was placed can be given again");
    }

    void OnDisable()
    {
        I_BuildingsManager.OnBuilding_placable -= BuildingCanBePlaced;
    }

    #endregion
}
