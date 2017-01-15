using UnityEngine;

public class EmptyState : MonoBehaviour, IState
{
    public StateMachine gameStateManager;

    public void OnUpdate()
    {

    }
    public void OnEnter()
    {
        print("Empty STate Enter");
    }
    public void OnExit()
    {
        print("Empty State Exit");
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.ChangeState("World Map State (WorldMapState)");
        }
    }
}
