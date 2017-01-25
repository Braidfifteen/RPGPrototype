using UnityEngine;

// This script will be attached to the parent game object of each individual state. It will control the flow of that specific
public class StateParentScript : MonoBehaviour, IState
{
    public SubStateMachine subState;

    // This is used if needed
    public StateMachine gameStateManager;

    public bool ActivateOnEnter = true;
    public bool DeactivateOnExit = true;

    private IUpdatable[] updateObjects;
    private IInput[] inputObjects;
    private IExitable[] exitObjects;
    private IEnterable[] enterObjects;
    private ILateEnter[] lateEnterObjects;
    private IEarlyEnter[] earlyEnterObjects;

    private void Awake()
    {
        inputObjects = GetComponentsInChildren<IInput>();
        updateObjects = GetComponentsInChildren<IUpdatable>();
        exitObjects = GetComponentsInChildren<IExitable>();
        enterObjects = GetComponentsInChildren<IEnterable>();
        lateEnterObjects = GetComponentsInChildren<ILateEnter>();
        earlyEnterObjects = GetComponentsInChildren<IEarlyEnter>();
    }

    public void OnUpdate()
    {
        if (subState == null && gameStateManager == null)
        {
            print("STATE PARENT SCRIPT MISSING STATE MANAGER");
            print(transform.gameObject);
        }

        for (int i = 0; i < updateObjects.Length; i++)
            updateObjects[i].OnUpdate();
    }

    public void OnEnter()
    {
        if (ActivateOnEnter)
        {
            if (!transform.gameObject.activeInHierarchy)
                transform.gameObject.SetActive(true);
        }

        for (int i = 0; i < earlyEnterObjects.Length; i++)
            earlyEnterObjects[i].OnEarlyEnter();

        for (int i = 0; i < enterObjects.Length; i++)
            enterObjects[i].OnEnter();

        for (int i = 0; i < lateEnterObjects.Length; i++)
            lateEnterObjects[i].OnLateEnter();
    }

    public void OnExit()
    {
        for (int i = 0; i < exitObjects.Length; i++)
            exitObjects[i].OnExit();

        if (DeactivateOnExit)
        {
            if (transform.gameObject.activeInHierarchy)
                transform.gameObject.SetActive(false);
        }
    }

    public void HandleInput()
    {
        for (int i = 0; i < inputObjects.Length; i++)
            inputObjects[i].GetInput();
    }
}
