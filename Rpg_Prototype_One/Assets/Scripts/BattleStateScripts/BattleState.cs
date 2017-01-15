using UnityEngine;

public class BattleState : MonoBehaviour, IState
{
    public StateMachine gameStateManager;

    public void OnUpdate()
    {

    }

    public void OnEnter()
    {
        if (!transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(true);
        }
    }

    public void OnExit()
    {
        if (transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameStateManager.ChangeState("World Map State (WorldMapState)");
        }
    }
}
