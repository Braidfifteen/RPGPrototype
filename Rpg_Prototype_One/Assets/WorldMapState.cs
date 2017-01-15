using UnityEngine;
using System.Collections.Generic;

public class WorldMapState : MonoBehaviour, IState
{
    private IUpdatable[] updateObjects;
    private IInput[] inputObjects;

    private void Start()
    {
        inputObjects = GetComponentsInChildren<IInput>();
        updateObjects = GetComponentsInChildren<IUpdatable>();
    }

    public void OnUpdate()
    {
        for (int i = 0; i < updateObjects.Length; i++)
        {
            updateObjects[i].OnUpdate();
        }
    }

    public void OnEnter() { }

    public void OnExit()
    {

    }

    public void HandleInput()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetInput();
        }
    }
}
