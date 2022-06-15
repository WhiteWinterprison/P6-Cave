using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
   
    public List<Building> Buildings = new List<Building>();

    public Transform buildingContent;
    public GameObject InventoryItem;


    public static InventoryManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Add(Building building)
    {
        Buildings.Add(building);
    }

    public void Remove(Building building)
    {
        Buildings.Remove(building);
    }

    public void ListBuildings()
    {
        foreach(Transform building in buildingContent)
        {
           Destroy(InventoryItem.gameObject);
        }

        foreach (var building in Buildings)
        {
            GameObject obj = Instantiate(InventoryItem, buildingContent);

            Debug.Log("Item created");

           
            var buildingName = obj.transform.Find("Building Name").GetComponent<Text>(); 
            var buildingImg = obj.transform.Find("Img").GetComponent<Image>();
            
     
            buildingName.text = building.buildingName;
            buildingImg.sprite = building.img;

            Debug.Log("Item Listed");
        }
    }
}
