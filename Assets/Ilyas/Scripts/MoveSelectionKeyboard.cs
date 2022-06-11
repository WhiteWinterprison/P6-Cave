using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//This script is solely created to be used for debugging with the keyboard, it is used to select objects to connect with each other

public class MoveSelectionKeyboard : MonoBehaviour
{
    private float speed = 10;
    bool isHoverSelectableObject;
    private List<GameObject> SelectableObjects;
    private PlayerInput playerInput;
    private DebugAction debugAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        debugAction = new DebugAction();

        debugAction.Debugging.Enable();
        debugAction.Debugging.Select.performed += Select_performed;
        debugAction.Debugging.Activate.performed += Activate_performed;
       
    }

   

    private void Activate_performed(InputAction.CallbackContext obj)
    {
        
        activateObject();
    }

    private void Select_performed(InputAction.CallbackContext obj)
    {
        
        selectObject();
    }

    private void Start()
    {
        SelectableObjects = new List<GameObject>();
    }

    void Update()
    {
        
        Vector2 inputVector = debugAction.Debugging.Movement.ReadValue<Vector2>();
        moveDebug(inputVector);
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

    private void moveDebug(Vector2 moveVector)
    {
        Vector3 moveInput = new Vector3(moveVector.x, 0, moveVector.y);
        transform.position = transform.position + moveInput * speed * Time.deltaTime;

    }

    private void selectObject()
    {
        
        //SelectObject
        if (SelectableObjects.Count > 0)
        {
            GameObject obj = SelectableObjects[0];
            SelectableObjects.RemoveAt(0);
            obj.GetComponent<SelectableObject>().SelectionOccured();
        }
    }

    public void activateObject() 
    {
        //ActivateObject
        if (SelectableObjects.Count > 0)
        {
            GameObject obj = SelectableObjects[0];
            SelectableObjects.RemoveAt(0);
            obj.GetComponent<SelectableObject>().ActivationOccured();
        }
    }


}
