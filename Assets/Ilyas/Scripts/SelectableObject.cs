using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SelectableObject : MonoBehaviour
{
    [SerializeField]
    private UnityEvent DoWhenSelected;

    [SerializeField]
    private UnityEvent DoWhenActivated;
    

    public void SelectionOccured()
    {
        if(DoWhenSelected != null)
            DoWhenSelected.Invoke();
        Debug.Log("selected");
    }

    public void ActivationOccured()
    {
        if (DoWhenActivated != null)
            DoWhenActivated.Invoke();
        Debug.Log("activated");
    }
}
