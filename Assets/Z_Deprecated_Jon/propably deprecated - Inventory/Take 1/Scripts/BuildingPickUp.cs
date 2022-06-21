using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPickUp : MonoBehaviour
{
    public Building building;

    InventoryManager inventoryManager;

    public void Pickup()
    {
        InventoryManager.Instance.Add(building);

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();       
    }
}
