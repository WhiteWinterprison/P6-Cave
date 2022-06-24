//---------by Isabel Bartelmus-----------
//You need CaveTable & VrBelt on 2 obj to make this work
//-----------24.06.22-------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    }
    #endregion

    //------------------Events------------------
     public static event Action OnBuilding_givable;
     public static event Action OnBuilding_placable;

    //------------------Variabels------------------

    [SerializeField]private bool canBePlaced= false;
    [SerializeField]private bool CanBeGiven=false ;

    void Start()
    {
        //Subscribing as a Listener to following events:
        I_CaveTable.OnBuildingGiven += BuildingIsGiven;
        I_VrBelt.OnBuildingPlaced += BuildingIsPlaced;
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
}
