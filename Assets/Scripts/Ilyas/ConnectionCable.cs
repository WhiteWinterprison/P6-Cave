using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionCable : MonoBehaviour
{
    // buildings connected by cable
    [HideInInspector]
    public BuildToConnect StartConnect;

    [HideInInspector]
    public BuildToConnect EndConnect;

    // Transform of cable
    private Vector3 initialScale;

    //Need to call the cablemanager on occasion
    private CableManagement CableManager;


    [SerializeField]
    private float maxEnergy = 100;
    
    private float currentEnergy = 0;

    private Renderer _renderer;

    [SerializeField]
    private GameObject childWithShader;

    private Material mat;
    private void Start()
    {
        mat = childWithShader.GetComponent<Renderer>().material;
        _renderer = GetComponent<Renderer>();
        initialScale = transform.localScale;
        CableManager = FindObjectOfType<CableManagement>();

    }
    private void Update()
    {
        if (checkConnect())
        {
            if (_renderer)
                _renderer.enabled = true;
            changeTransform();

        } else
        {
            if(_renderer)
                _renderer.enabled = false;
            //make object invisible later
        }
        Debug.Log(currentEnergy);
        if(mat)
            mat.SetFloat("_ElectricityNoiseScale", currentEnergy);
    }


    
    //return energy available
    public float energyAvailable()
    {
        return maxEnergy - currentEnergy;
    }


    public bool checkConnect()
    {
        if(StartConnect != null && EndConnect != null)
        {
            return true;
        }
        return false;
    }

    public void removeConnections()
    {   
        if(StartConnect)
            StartConnect.removeCable(this);
        if(EndConnect)
            EndConnect.removeCable(this);
    }

    private void changeTransform() 
    {
        //Determine distance to scale object 
        float distance = Vector3.Distance(StartConnect.transform.position, EndConnect.transform.position);
        transform.localScale = new Vector3(initialScale.x, distance / 2, initialScale.z);

        //Determine middlPoint for Object anchor
        Vector3 middlePoint = (StartConnect.transform.position + EndConnect.transform.position) / 2f;
        transform.position = middlePoint;

        //Determine object rotation
        Vector3 rotationDirection = (StartConnect.transform.position - EndConnect.transform.position);
        transform.up = rotationDirection;

    }

    public void removeThisCable()
    {
        CableManager.terminateCable(this);
    }

    public void transmitEnergy(BuildToConnect buildSendEnergy, float energyToTransfer)
    {
        if (checkConnect())
        {
            if (buildSendEnergy == StartConnect)
            {
                StartConnect.ConsumeEnergy(energyToTransfer);
                EndConnect.receiveEnergy(energyToTransfer);
                currentEnergy += energyToTransfer;
            }
            if (buildSendEnergy == EndConnect)
            {
                EndConnect.ConsumeEnergy(energyToTransfer);
                StartConnect.receiveEnergy(energyToTransfer);
                currentEnergy += energyToTransfer;
            }
        }
    }

    public void resetEnergy()
    {
        currentEnergy = 0;
    }
}
