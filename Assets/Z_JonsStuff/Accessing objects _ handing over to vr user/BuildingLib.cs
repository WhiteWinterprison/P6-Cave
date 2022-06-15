// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// [ ] numbers need to be accessible for both users (cave/vr)
// [ ]            server communication - sending data to other users - updating the int values on runtime & on manipulation
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BuildingLib : MonoBehaviour
{
    [Header("Airport")]
    public int airportAmount;
    public GameObject airport;


    [Header("Hospital")]
    public int hospitalAmount;
    public GameObject hopsital;


    [Header("Store")]
    public int storeAmount;
    public GameObject store;

    private void Update()
    {
        SetMinimum();
    }

    private void SetMinimum()
    {
        if (airportAmount <= 0)
        {
            airportAmount = 0;
        }

        if (hospitalAmount <= 0)
        {
            hospitalAmount = 0;
        }

        if (storeAmount <= 0)
        {
            storeAmount = 0;
        }
    }
}
