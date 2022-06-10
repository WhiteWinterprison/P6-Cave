//this is the script for placing buildings that are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    //GameObject placedBuilding;
    //Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            transform.position = hit.point;
        }

        if(Input.GetMouseButton(0))
        {
                Instantiate(prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
        }
    }

    /*private bool CanPlaceBuilding(GameObject placedBuilding, Vector3 position)
    {
        BoxCollider buildCollider = placedBuilding.GetComponent<BoxCollider>();

        if (Physics.CheckBox(position, buildCollider.size / 2, Quaternion.identity, 3) != null)
        {
            Debug.Log(buildCollider.name);
            return false;
        }
        else
        {
            return true;
        }
    }*/
}
