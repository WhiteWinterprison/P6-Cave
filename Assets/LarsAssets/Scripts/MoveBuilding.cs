//this is the script for moving buildings that are placed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBuilding : MonoBehaviour
{
    RaycastHit hit;
    //Vector3 movePoint;

    //private Vector3 mOffset;
    //private float mYCoord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
             transform.position = hit.point;
        }
    }

    /*private bool CanPlaceBuilding()
    {
        BoxCollider buildCollider = this.GetComponent<BoxCollider>();

        if (Physics.OverlapBox(hit.point, buildCollider.size / 2, Quaternion.identity, 3) != null)
        {
            //Debug.Log("can't move building");
            return false;
        }
        else
        {
            return true;
        }
    }*/
}
