using UnityEngine;

public class BattleStateEnter : MonoBehaviour, IState
{
    public SubStateMachine battleStateManager;

    private float counter = 0.0f;
    private float stateDuration = 3.0f;

    public void OnUpdate()
    {
        print("Battle State Enter");
        counter += Time.deltaTime;
        if (counter >= stateDuration)
            battleStateManager.ChangeState(1);
    }

    public void OnEnter()
    {
        counter = 0.0f;
    }

    public void OnExit()
    {

    }

    public void HandleInput()
    {
        
    }
}
