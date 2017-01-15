using UnityEngine;

public class BattleState : MonoBehaviour, IState
{
    public StateMachine gameStateManager;

    private IUpdatable[] updateObjects;
    private IInput[] inputObjects;
    private IExitable[] exitObjects;
    private IEnterable[] enterObjects;

    private void Awake()
    {
        inputObjects = GetComponentsInChildren<IInput>();
        updateObjects = GetComponentsInChildren<IUpdatable>();
        exitObjects = GetComponentsInChildren<IExitable>();
        enterObjects = GetComponentsInChildren<IEnterable>();
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameStateManager.ChangeState("World Map State (WorldMapState)");
        }

        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetInput();
        }
    }
}
