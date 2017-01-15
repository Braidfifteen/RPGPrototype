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
                currentState = state;

            }
            catch (NullReferenceException)
            {
                continue;
            }
        }

    }

    private void Update()
    {
         currentState.HandleInput();
         currentState.OnUpdate();
    }
}
