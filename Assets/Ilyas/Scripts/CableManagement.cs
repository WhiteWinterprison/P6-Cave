using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CableManagement : MonoBehaviour
{
    private List<ConnectionCable> connectionCables;

    private static CableManagement Instance {  get; set; }

    private bool isCableActive { get; set; }
    private ConnectionCable activeCable;


    //Prefab of the Cable 

    [SerializeField]
    private GameObject cablePrefab;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {      
        
        //checks if prefab contains a ConnectionCable component, disables itself if not
        if (cablePrefab.GetComponent<ConnectionCable>() == null)
        {
            this.gameObject.SetActive(false);
        }

        connectionCables = new List<ConnectionCable>();

    }
    public void createCable(GameObject obj) 
    {
        
        //Creates Cable and sets Cables Start to obj component BuildToConnect 
        if (!isCableActive && obj.GetComponent<BuildToConnect>())
        {
            //creates the gameobject prefab with a ConnectionCable component
            GameObject cableObj;
            cableObj =  Instantiate(cablePrefab);

            //sets ActiveCable to the CableComponent of the newly created gameObject
            activeCable = cableObj.GetComponent<ConnectionCable>();

            //Sets the startConnection of the activeCable
            activeCable.StartConnect = obj.GetComponent<BuildToConnect>();

            obj.GetComponent<BuildToConnect>().addCable(activeCable);
            connectionCables.Add(activeCable);
            isCableActive = true;
        }
        //sets active cables end to another objectsBuildToConnect Component, terminate cable otherwise
        else if (isCableActive)
        {
            if (obj != activeCable.StartConnect.gameObject && obj.GetComponent<BuildToConnect>())
            {
                activeCable.EndConnect = obj.GetComponent<BuildToConnect>();
                obj.GetComponent<BuildToConnect>().addCable(activeCable);
            } else
            {
                terminateCable(activeCable);
            }

            isCableActive = false;
        }
    }

    //Clears connections and destroys Cable (Implement object pooling!)
    public void terminateCable(ConnectionCable cable) 
    {

        
        connectionCables.Remove(cable);
        cable.removeConnections();
        cable.gameObject.SetActive(false);
        Destroy(cable.gameObject, 0.2f);
    }
}
