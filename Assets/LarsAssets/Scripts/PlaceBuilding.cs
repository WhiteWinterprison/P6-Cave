//this is the script for placing buildings that are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    RaycastHit hit;
    public GameObject prefab;


    // script for mouse interaction

    // Start is called before the first frame update
    /*void Start()
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
    }*/


    //script for VR interaction
    /*void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }*/
}
