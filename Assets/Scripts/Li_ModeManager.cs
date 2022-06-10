//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: State Machine to control the Switch between Building and Simulating Mode


//What it do:
// - provides the ground work for a state machine
// - provides the base class for the Mode Manager with build and simulate states
// - holds the two state classes from the state machine (Build and Simulation)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Li_ModeManager
{
    //define possible states as enumeration
    //ENUM always with capital letters
    public enum STATE
    {
        BUILD, SIMULATE
    };

    //the three phases of the states
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    //what state is it
    public STATE name;

    protected EVENT stage; //phase the state is in
    protected Li_ModeManager nextState; //ref to the state maschine (not ENUM)
    protected GameObject button; //ref to the switch button
    protected bool clicked = false; //bool to check for button to switch modes
    protected string modeText;

    //constructor to create the different states
    public Li_ModeManager(GameObject _button)
    {
        stage = EVENT.ENTER;
        button = _button;
    }

    //defining the three stages
    public virtual void Enter() { stage = EVENT.UPDATE; } //calling Enter sets the state from the enter to the update stage
    public virtual void Update() { stage = EVENT.UPDATE; } //calling Update makes the state stay in the update stage
    public virtual void Exit() { stage = EVENT.EXIT; } //calling Exit calls the function that should be done to exit the current state

    //this function gets called from the outside to go from one state to the next
    public Li_ModeManager Process()
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

    public void SwitchClicked()
    {
        if (clicked) clicked = false;
        else clicked = true;
    }
}

public class BuildMode : Li_ModeManager
{
    public BuildMode(GameObject _button)
        : base(_button) //hand over the values to the base class
    {
        name = STATE.BUILD;
        button = _button;
        modeText = "Build Mode";
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        //set the button text
        if (button.GetComponentInChildren<TextMeshProUGUI>().text != modeText) button.GetComponentInChildren<TextMeshProUGUI>().text = modeText;

        //switch the mode if button was clicked
        if (clicked)
        {
            SwitchClicked();
            nextState = new SimulationMode(button); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class SimulationMode : Li_ModeManager
{
    public SimulationMode(GameObject _button)
        : base(_button) //hand over the values to the base class
    {
        name = STATE.SIMULATE;
        button = _button;
        modeText = "Simulation Mode";
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();

        //set the button text
        if (button.GetComponentInChildren<TextMeshProUGUI>().text != modeText) button.GetComponentInChildren<TextMeshProUGUI>().text = modeText;

        //switch the mode if button was clicked
        if (clicked)
        {
            SwitchClicked();
            nextState = new BuildMode(button); //the next state is the angry state
            stage = EVENT.EXIT; //leave this state
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
