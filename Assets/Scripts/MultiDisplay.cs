using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    void createMultiDisplay()
    {

        Debug.Log(Display.displays.Length);

        for (int i=1; i< Display.displays.Length; i++)
            Display.displays[i].Activate();

    }    
}
