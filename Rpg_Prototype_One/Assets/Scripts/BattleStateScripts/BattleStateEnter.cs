using UnityEngine;

public class BattleStateEnter : MonoBehaviour, IState
{
    public SubStateMachine battleStateManager;
    public CharactersInBattleState characters;

    private float counter = 0.0f;
    private float stateDuration = 3.0f;

    public void OnUpdate()
    {

        counter += Time.deltaTime;
        if (counter >= stateDuration)
            battleStateManager.ChangeState(1);
    }

    public void OnEnter()
    {
        print("BattleStateEnter OnEnter()");
        characters.SetupEnemySpots();
        counter = 0.0f;
    }

    public void OnExit()
    {
        print("BattleStateEnter OnExit()");
    }

    public void HandleInput()
    {
        
    }
}
