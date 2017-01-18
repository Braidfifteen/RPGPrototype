using UnityEngine;
using System;
using System.Collections.Generic;

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
