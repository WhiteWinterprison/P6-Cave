using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class I_SceneSwitch : MonoBehaviour
{
    private int Counter  ;

    void start(){
        Counter = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("SceneNR:" + Counter);
    }

    public void CounterUp(){
        Counter+=1;
        SwitchSceneToNr();
    }

    public void CounterDown(){
         Counter-=1;
        SwitchSceneToNr();
    }

   public void SwitchSceneToNr()
   {

        SceneManager.LoadScene(Counter);
        Debug.Log("SceneNR:" + Counter);
   }
}
