using UnityEngine;

public class SelectCharacter : MonoBehaviour, IState
{
    public SubStateMachine battleStateManager;

    private IUpdatable[] updateObjects;
    private IInput[] inputObjects;
    private IExitable[] exitObjects;
    private IEnterable[] enterObjects;
    private ILateEnter[] lateEnterObjects;

    private void Awake()
    {
        inputObjects = GetComponentsInChildren<IInput>();
        updateObjects = GetComponentsInChildren<IUpdatable>();
        exitObjects = GetComponentsInChildren<IExitable>();
        enterObjects = GetComponentsInChildren<IEnterable>();
        lateEnterObjects = GetComponentsInChildren<ILateEnter>();
    }

    public void OnUpdate()
    {
        for (int i = 0; i < updateObjects.Length; i++)
        {
            updateObjects[i].OnUpdate();
        }
    }

    public void OnEnter()
    {
        if (!transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(true);
        }

        for (int i = 0; i < enterObjects.Length; i++)
        {
            enterObjects[i].OnEnter();
        }

        for (int i = 0; i < lateEnterObjects.Length; i++)
        {
            lateEnterObjects[i].OnLateEnter();
        }
    }

    public void OnExit()
    {
        if (transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(false);
        }

        for (int i = 0; i < exitObjects.Length; i++)
        {
            exitObjects[i].OnExit();
        }
    }

    public void HandleInput()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetInput();
        }
    }
}
