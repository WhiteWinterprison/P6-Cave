//--------created by : Isabel 14.06.22------
//fast & dirty solution for the invetory for monday the 27.02.22
//this will be removed when the Building Manager works
//but its to late for my brain to make it work in 5 h ^^

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class I_EnableSocketInteractor : MonoBehaviour
{
    [SerializeField] private GameObject SocketCave;
    [SerializeField] private GameObject SocketVR;
      
    void Awake()
    {
        SocketVR.SetActive(false);
    }


    public void ShowCaveSocket()
    {
        SocketCave.SetActive(true);
        SocketVR.SetActive(false);
    }

    public void ShowVrSocket()
    {
        SocketCave.SetActive(false);
        SocketVR.SetActive(true);
    }
}
