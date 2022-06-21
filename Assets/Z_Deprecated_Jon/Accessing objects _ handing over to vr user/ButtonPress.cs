using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    // function which triggers on button press
    // private void Enable[building name]
    // - add [building name] to users list  <- object pooling - create disabled object, set active on instantiation to target point
    // - 
    //

    public BuildingLib buildingLib;

    public void GiveAirport()
    {
        buildingLib.airportAmount++;
        Debug.Log("Airport has been given");
    }

    public void GiveHospital()
    {
        buildingLib.hospitalAmount++;
        Debug.Log("Hospital has been given");
    }

    public void GiveStore()
    {
        buildingLib.storeAmount++;
        Debug.Log("Store has been given");
    }

}
