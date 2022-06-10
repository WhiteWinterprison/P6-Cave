using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SelectableObject : MonoBehaviour
{

    public UnityEvent DoWhenSelected;
   

    public void SelectionOccured()
    {
        DoWhenSelected.Invoke();
        Debug.Log("selected");
    }
}
