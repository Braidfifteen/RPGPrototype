using UnityEngine;
using System;
using System.Collections.Generic;

//
// This script is attached to the Game State Manager. It controls the flow of the entire program and is the only
// script which unity calls Update() on, in which this script calls currentStates OnUpdate().
//
// The order of script calls is as follows:
// -- Game State Manager/StateMachine calls either a SubStateMachine or a StateParentScript.
// StateParentScript is attached to the parent gameObject, which each state has. StateParenScript has OnUpdate(), OnEnter(), OnExit(), etc, which will call the child gameObjects IUpdatable, IEnterable, IExitable, etc.
// SubStateMachine has the same funcionality as StateParentScript, except that it is also it's own state machine. This Script is used for the parent gameObject of a state if the state needs to keep track of it's own states, and child gameObjects of this state will use StateParentScript which will call IUpdatable, IEnterable, IExitable in its child gameObjects. 
//

public class StateMachine : MonoBehaviour
{
    private Dictionary<string, IState> stateDict = new Dictionary<string, IState>();
    private IState currentState;
    public GameObject[] objectsWithState;

    private void Start()
    {
        for (int i = 0; i < objectsWithState.Length; i++)
        {
            try
            {
                IState state = objectsWithState[i].GetComponent<IState>();
                string type = state.ToString();
                stateDict.Add(type, state);
            }
            catch (NullReferenceException)
            {
                continue;
            }
        }
        currentState = stateDict[objectsWithState[0].GetComponent<IState>().ToString()];
    }

    private void Update()
    {
         currentState.HandleInput();
         currentState.OnUpdate();
    }

    public void ChangeState(string stateID)
    {
        currentState.OnExit();
        currentState = stateDict[stateID];
        currentState.OnEnter();
    }

    public void ChangeState(int indexID)
    {
        currentState.OnExit();
        currentState = stateDict[objectsWithState[indexID].GetComponent<IState>().ToString()];
        currentState.OnEnter();
    }
}
