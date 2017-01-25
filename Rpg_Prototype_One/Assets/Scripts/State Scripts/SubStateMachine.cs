using UnityEngine;
using System.Collections.Generic;
using System;

// This script is the exact same as StateMachine, except it uses On methods (OnUpdate(), OnEnter()) instead of just
// regular Update(). This is because certain states may want to use their own state machine, but to ensure that
// Game State Manager has complete control over the update cycle, this sub state machine will not interfere with Unitys
// call to Update() methods.
public class SubStateMachine : MonoBehaviour, IState
{
    public GameObject[] objectsWithState;
    public StateMachine gameStateManager;
    public SubStateMachine subState;
    public bool ActivateOnEnter = true;
    public bool DeactivateOnExit = true;

    // I want to get away from the use of strings so I want to change this dictionary at somepoint
    private Dictionary<string, IState> stateDict = new Dictionary<string, IState>();
    private IState currentState;


    private void Awake()
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

    public void OnUpdate()
    {
        currentState.OnUpdate();
    }

    public void OnEnter()
    {
        if (ActivateOnEnter)
        {
            if (!transform.gameObject.activeInHierarchy)
                transform.gameObject.SetActive(true);
        }
        currentState.OnEnter();
    }

    public void OnExit()
    {
        if (DeactivateOnExit)
        {
            if (transform.gameObject.activeInHierarchy)
                transform.gameObject.SetActive(false);
        }
        currentState = stateDict[objectsWithState[0].GetComponent<IState>().ToString()];
    }

    public void HandleInput()
    {
        currentState.HandleInput();
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

    public void ChangeGameState(int indexID)
    {
        currentState.OnExit();
        gameStateManager.ChangeState(0);
    }
}
