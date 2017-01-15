using UnityEngine;

public class EmptyState : MonoBehaviour, IState
{
   public void OnUpdate()
    {
        print("EmptyStateUpdate");
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
        print("Empty state input");
    }
}
