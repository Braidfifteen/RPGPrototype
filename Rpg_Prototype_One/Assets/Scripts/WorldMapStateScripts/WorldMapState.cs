using UnityEngine;

public class WorldMapState : MonoBehaviour, IState
{
    public StateMachine gameStateManager;

    private IUpdatable[] updateObjects;
    private IInput[] inputObjects;
    private IExitable[] exitObjects;
    private IEnterable[] enterObjects;

    private void Start()
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
        print("World Map State Enter");
        for (int i = 0; i < enterObjects.Length; i++)
        {
            enterObjects[i].OnEnter();
        }
    }

    public void OnExit()
    {
        print("World Map State Exit.");
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.ChangeState("Empty State (EmptyState)");
        }
    }
}
