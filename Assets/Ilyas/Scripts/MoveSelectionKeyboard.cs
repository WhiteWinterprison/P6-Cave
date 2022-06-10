using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is solely created to be used for debugging with the keyboard, it is used to select objects to connect with each other

public class MoveSelectionKeyboard : MonoBehaviour
{
    private float speed = 10;
    bool isHoverSelectableObject;
    private List<GameObject> SelectableObjects;

    private void Start()
    {
        SelectableObjects = new List<GameObject>();
    }

    void Update()
    {
        //MoveSelectionTool
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position = transform.position + moveInput * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //SelectObject
            if (SelectableObjects.Count > 0)
            {
                GameObject obj = SelectableObjects[0];
                SelectableObjects.RemoveAt(0);
                obj.GetComponent<SelectableObject>().SelectionOccured();
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SelectableObject>())
        {
            SelectableObjects.Add(other.gameObject);
        }
    }
  

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<SelectableObject>())
        {
            SelectableObjects.Remove(other.gameObject);
        }
    }
}
