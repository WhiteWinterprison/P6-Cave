using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class SteamTrackerSetup : MonoBehaviour
{
    public List<SteamVR_TrackedObject> trackers;

    //Code by Noah Pfeifer @Halbzwilling (04th of May '22)

    //HOW TO USE: 
    //Add this Script to an empty Game Object.
    //Add every "SteamVR_TrackedObject" GameObject that you want to be tracked into the Trackers List
    //Durin Runtime, you can press the 1-5 number Keys on your Keyboard to change the Tracker's Index, starting from the Number pressed.
    //Make sure that all your trackers are connected after each other and not before a controller or the hmd.
    //If you're just using a Headset with Controllers, press 1. Otherwise just look at your connected devices list and start counting at 0.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) ChangeTrackerIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeTrackerIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeTrackerIndex(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeTrackerIndex(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeTrackerIndex(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) ChangeTrackerIndex(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) ChangeTrackerIndex(6);
    }

    void ChangeTrackerIndex(int index)
    {
        for (int i = 0; i < trackers.Count; i++)
        {
            Debug.Log("Tracker Index changed to be starting at: " + index);
            trackers[i].SetDeviceIndex(index + i);
        }
    }
}
