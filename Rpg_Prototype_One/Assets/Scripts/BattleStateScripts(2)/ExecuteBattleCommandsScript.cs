using UnityEngine;

public class ExecuteBattleCommandsScript : MonoBehaviour, IEnterable
{
    public StateParentScript stateManager;
    public PlayerSelectionsContainer BattleCommands;
    public AllActiveBattleSpotsScript ActiveSpots;
    public TurnManager turnManager;

    private ICommand command;
    private GameObject commandingCharacter;
    private GameObject targetCharacter;

    public void OnEnter()
    {
        command = BattleCommands.GetCommand();
        commandingCharacter = BattleCommands.CommandingCharacter;
        targetCharacter = BattleCommands.TargetCharacter;

        command.Execute(commandingCharacter, targetCharacter);

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
