using UnityEngine;

public class ExecuteBattleCommandsScript : MonoBehaviour, IEnterable, IUpdatable
{
    public StateParentScript stateManager;
    public PlayerSelectionsContainer BattleCommands;
    public AllActiveBattleSpotsScript ActiveSpots;
    public TurnManager turnManager;
    public BattleDamageNumbersManager battleDamageNumbers;

    private ICommand command;
    private GameObject commandingCharacter;
    private GameObject targetCharacter;

    public void OnEnter()
    {
        command = BattleCommands.GetCommand();
        commandingCharacter = BattleCommands.CommandingCharacter;
        targetCharacter = BattleCommands.TargetCharacter;
        command.SetObject(battleDamageNumbers);
        command.Execute(commandingCharacter, targetCharacter);
    }

    public void OnUpdate()
    {
        command.UpdateCommand();
        if (!command.IsUpdating())
            exit();
    }

    private void exit()
    {
        turnManager.ChangeTurn();

        if (ActiveSpots.AllActiveEnemySpots.Count > 0 && ActiveSpots.AllActivePlayerSpots.Count > 0)
        {
            if (turnManager.IsPlayerTurn)
            {
                stateManager.subState.ChangeState(1);
            }

            else
            {
                stateManager.subState.ChangeState(5);
            }
        }
        else
            stateManager.subState.ChangeState(4);
    }
}
