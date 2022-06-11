using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class I_SceneSwitch : MonoBehaviour
{
    private int Counter = 0;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Counter -= 1;
            Debug.Log("Scene Coutner:" + Counter);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Counter +=1;
            
            Debug.Log("Scene Coutner:" + Counter);
        }
        if(Counter <=0)
        {
            Counter=0;
            
            Debug.Log("Stop" + Counter);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            SwitchSceneToNr();
        }
        
    }

   public void SwitchSceneToNr()
   {

        SceneManager.LoadScene(Counter);
   }
}
