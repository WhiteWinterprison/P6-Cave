//this is the script for placing buildings that are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

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
            if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 6)))
            {
                transform.position = hit.point; 
            }
            else
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
