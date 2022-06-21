using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildToConnect : MonoBehaviour
{
    
    private CableManagement CableManager;

    //all cables connected with building
    private List<ConnectionCable> Connections;



    //Energy need
    [SerializeField]
    private float energyNeed = 0;
    [SerializeField]
    private float energyProduction = 0;
    private float currentEnergy;

    [SerializeField]
    private float customEnergyToSend = 15;

    //both bool for debugging purposes
    public bool isSendAll;
    public bool isDebug;


    private void Start()
    {
        currentEnergy = energyProduction;
        CableManager = FindObjectOfType<CableManagement>();
        Connections = new List<ConnectionCable>();
    }


    private void Update()
    {
        if (isSendAll)
        {
            sendAllEnergy(); // for debugging purposes
        }

        if(isDebug)
            Debug.Log(currentEnergy);
    }




    //Add cable to List(Connections), will be called by cablemanager
    public void addCable(ConnectionCable cable) 
    {
        Connections.Add(cable);
    }

    //Remove cable from List(Connections), will be called by cablemanager
    public void removeCable(ConnectionCable cable)
    {
        Connections.Remove(cable);
    }


    //Calls createCable function of the cable manager, will be called externally
    public void createCable()
    {
        if (CableManager)
        {
            CableManager.createCable(this.gameObject);
        }
    }


    

    //Checks if energy demant met, if not request 
    private bool checkMeetEnergyDemant()
    {
        if (energyNeed <= currentEnergy)
            return true;
        
        return false;
    }

    private void sendEnergy(ConnectionCable cable, float energy)
    {
        
        
            float cableAvailableEnergy = cable.energyAvailable();
            if (currentEnergy > energy)
            {
                if (energy <= cableAvailableEnergy)
                {

                    cable.transmitEnergy(this, energy);
                }
                else
                {
                    cable.transmitEnergy(this, cableAvailableEnergy);
                }
            } else
            {
                if (currentEnergy <= cableAvailableEnergy)
                {

                    cable.transmitEnergy(this, currentEnergy);
                }
                else
                {
                    cable.transmitEnergy(this, cableAvailableEnergy);
                }

            }
        
    }

    public void receiveEnergy(float energy)
    {
        currentEnergy += energy;
    }

    public void ConsumeEnergy(float energyToConsume)
    {
        currentEnergy -= energyToConsume;
    }

    //DebugTool to send all energy

    public void sendAllEnergy()
    {
        foreach (ConnectionCable item in Connections)
        {
            sendEnergy(item, currentEnergy);
        }
    }

    //When Activated externally will send custom Energy to each connected cable
    public void sendCustomEnergy()
    {
        foreach (ConnectionCable item in Connections)
        {
            sendEnergy(item, customEnergyToSend);
        }
    }
}
