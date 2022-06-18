//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: State Machine to detect and handle the correct Player Setup


//What it do:
// - provides the ground work for a state machine
// - provides the base class for the Setup States with VR, CAVE and default states
// - holds the three state classes from the state machine (VR, CAVE and default)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Li_SetupStates
{
    //define possible states as enumeration
    //ENUM always with capital letters
    public enum STATE
    {
        DEFAULT, CAVE, VR
    };

    //the three phases of the states
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    //what state is it
    public STATE name;

    protected EVENT stage; //phase the state is in
    protected Li_SetupStates nextState; //ref to the state maschine (not ENUM)
    protected GameObject myPrefab;
    protected string myName;
    protected GameObject defaultPrefab; //ref to the player prefab for desktop
    protected string defaultName; //ref to the desktop prefabs name
    protected GameObject cavePrefab; //ref to the player prefab for CAVE
    protected string caveName; //ref to the CAVE prefabs name
    protected GameObject vrPrefab; //ref to the player prefab for CAVE
    protected string vrName; //ref to the CAVE prefabs name

    //constructor to create the different states
    public Li_SetupStates(GameObject _defaultPrefab, string _defaultName, GameObject _cavePrefab, string _caveName, GameObject _vrPrefab, string _vrName)
    {
        stage = EVENT.ENTER;
        defaultPrefab = _defaultPrefab;
        defaultName = _defaultName;
        cavePrefab = _cavePrefab;
        caveName = _caveName;
        vrPrefab = _vrPrefab;
        vrName = _vrName;
    }

    //defining the three stages
    public virtual void Enter() { stage = EVENT.UPDATE; } //calling Enter sets the state from the enter to the update stage
    public virtual void Update() { stage = EVENT.UPDATE; } //calling Update makes the state stay in the update stage
    public virtual void Exit() { stage = EVENT.EXIT; } //calling Exit calls the function that should be done to exit the current state

    //this function gets called from the outside to go from one state to the next
    public Li_SetupStates Process()
    {
        if (stage == EVENT.ENTER) Enter(); //if in enter, go to update
        if (stage == EVENT.UPDATE) Update(); //if in update, stay there until further notice
        if (stage == EVENT.EXIT) //if in exit, do the stuff to exit and then go to the next state
        {
            Exit();
            return nextState;
        }
        return this;
    }

    //------------------------------------//
    //HERE: Implement base class functions//
    //------------------------------------//

    //function to be able to enter the same state again (e.g. scene change)
    public void ReloadState(Li_SetupStates myState)
    {
        nextState = myState; //reload the state you are currently in
        stage = EVENT.EXIT; //leave the current state
    }
}

public class DefaultState : Li_SetupStates
{
    public DefaultState(GameObject _defaultPrefab, string _defaultName, GameObject _cavePrefab, string _caveName, GameObject _vrPrefab, string _vrName)
        : base(_defaultPrefab, _defaultName, _cavePrefab, _caveName, _vrPrefab, _vrName) //hand over the values to the base class
    {
        name = STATE.DEFAULT;
        defaultPrefab = _defaultPrefab;
        defaultName = _defaultName;
        cavePrefab = _cavePrefab;
        caveName = _caveName;
        vrPrefab = _vrPrefab;
        vrName = _vrName;
        myPrefab = _defaultPrefab;
        myName = _defaultName;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        if (GameObject.FindGameObjectsWithTag("Player") == null)
        {
            //Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().SpawnMyPlayer(myName, myPrefab);
        }

        if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 2)
        {
            nextState = new CaveState(defaultPrefab, defaultName, cavePrefab, caveName, vrPrefab, vrName); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
        else if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 3)
        {
            nextState = new VrState(defaultPrefab, defaultName, cavePrefab, caveName, vrPrefab, vrName); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().DestroyMyPlayer();
        base.Exit();
    }
}

public class CaveState : Li_SetupStates
{
    public CaveState(GameObject _defaultPrefab, string _defaultName, GameObject _cavePrefab, string _caveName, GameObject _vrPrefab, string _vrName)
        : base(_defaultPrefab, _defaultName, _cavePrefab, _caveName, _vrPrefab, _vrName) //hand over the values to the base class
    {
        name = STATE.CAVE;
        defaultPrefab = _defaultPrefab;
        defaultName = _defaultName;
        cavePrefab = _cavePrefab;
        caveName = _caveName;
        vrPrefab = _vrPrefab;
        vrName = _vrName;
        myPrefab = _cavePrefab;
        myName = _caveName;
    }

    public override void Enter()
    {
        //Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().SpawnMyPlayer(myName, myPrefab);
        Debug.Log("entered CAVE state");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 1)
        {
            stage = EVENT.EXIT; //leave this state
        }
        else if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 3)
        {
            nextState = new VrState(defaultPrefab, defaultName, cavePrefab, caveName, vrPrefab, vrName); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().DestroyMyPlayer();
        base.Exit();
    }
}

public class VrState : Li_SetupStates
{
    public VrState(GameObject _defaultPrefab, string _defaultName, GameObject _cavePrefab, string _caveName, GameObject _vrPrefab, string _vrName)
        : base(_defaultPrefab, _defaultName, _cavePrefab, _caveName, _vrPrefab, _vrName) //hand over the values to the base class
    {
        name = STATE.VR;
        defaultPrefab = _defaultPrefab;
        defaultName = _defaultName;
        cavePrefab = _cavePrefab;
        caveName = _caveName;
        vrPrefab = _vrPrefab;
        vrName = _vrName;
        myPrefab = _vrPrefab;
        myName = _vrName;
    }

    public override void Enter()
    {
        //Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().SpawnMyPlayer(myName, myPrefab);
        Debug.Log("entered VR state");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 2)
        {
            nextState = new CaveState(defaultPrefab, defaultName, cavePrefab, caveName, vrPrefab, vrName); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
        else if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 1)
        {
            nextState = new DefaultState(defaultPrefab, defaultName, cavePrefab, caveName, vrPrefab, vrName); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().DestroyMyPlayer();
        base.Exit();
    }
}
