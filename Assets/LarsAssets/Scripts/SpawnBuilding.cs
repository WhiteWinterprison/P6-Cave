//this is the script for spawning buildings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnABuilding(GameObject prefab)
    {
        Instantiate(prefab);
    }
}
