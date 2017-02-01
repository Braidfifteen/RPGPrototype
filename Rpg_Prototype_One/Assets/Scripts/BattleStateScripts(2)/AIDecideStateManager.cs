using UnityEngine;

public class AIDecideStateManager : MonoBehaviour, IEnterable, IUpdatable
{
    public StateParentScript stateParent;
    public PlayerSelectionsContainer selectionsContainer;
    public AllActiveBattleSpotsScript activeSpots;
    public AttackOptionCommand ForTestingCommand;
    private float counter = 0.0f;

    public void OnEnter()
    {
        GameObject commandEnemy = activeSpots.AllActiveEnemySpots[Random.Range(0, activeSpots.AllActiveEnemySpots.Count)];
        GameObject targetCharacter = activeSpots.AllActivePlayerSpots[Random.Range(0, activeSpots.AllActivePlayerSpots.Count)];
        selectionsContainer.AddAll(commandEnemy, targetCharacter, ForTestingCommand);
    }

    public void OnUpdate()
    {
        counter += Time.deltaTime;
        print(counter);
        if (counter >= 4)
        {
            print("Enemy attacking");
            stateParent.subState.ChangeState(3);
            counter = 0.0f;
        }
    }
}
