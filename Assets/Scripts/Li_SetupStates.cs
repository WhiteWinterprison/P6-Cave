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

    //constructor to create the different states
    public Li_SetupStates()
    {
        stage = EVENT.ENTER;
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
}

public class DefaultState : Li_SetupStates
{
    public DefaultState()
        : base() //hand over the values to the base class
    {
        name = STATE.DEFAULT;
    }

    public override void Enter()
    {
        Debug.Log("entered default state");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 2)
        {
            nextState = new CaveState(); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
        else if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 3)
        {
            nextState = new VrState(); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class CaveState : Li_SetupStates
{
    public CaveState()
        : base() //hand over the values to the base class
    {
        name = STATE.CAVE;
    }

    public override void Enter()
    {
        Debug.Log("entered CAVE state");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 1)
        {
            nextState = new DefaultState(); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
        else if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 3)
        {
            nextState = new VrState(); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class VrState : Li_SetupStates
{
    public VrState()
        : base() //hand over the values to the base class
    {
        name = STATE.VR;
    }

    public override void Enter()
    {
        Debug.Log("entered VR state");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 2)
        {
            nextState = new CaveState(); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
        else if (Li_NetworkManager.Instance.GetComponent<Li_PlayerSetup>().GetPlayerSetup() == 1)
        {
            nextState = new DefaultState(); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
