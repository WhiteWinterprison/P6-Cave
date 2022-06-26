//this is the script for placing buildings that are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    //public GameObject prefab;
    //bool placedBuilding;
    Renderer rend;

    public Material[] Materials;

    //script for VR interaction
    void Start()
    {
        //placedBuilding = false;
        Renderer rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(rend != null)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                    rend.material = Materials[1];
            }
            else
            {
                rend.material = Materials[0];
            }
        }
    }
}

//archive code

// script for mouse interaction

//RaycastHit hit;

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
}
*/