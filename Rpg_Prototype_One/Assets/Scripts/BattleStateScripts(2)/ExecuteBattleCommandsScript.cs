using UnityEngine;

public class ExecuteBattleCommandsScript : MonoBehaviour, IEnterable
{
    public StateParentScript stateManager;
    public PlayerSelectionsContainer BattleCommands;

    private ICommand command;
    private GameObject commandingCharacter;
    private GameObject targetCharacter;

    public void OnEnter()
    {
        command = BattleCommands.GetCommand();
        commandingCharacter = BattleCommands.CommandingCharacter;
        targetCharacter = BattleCommands.TargetCharacter;

        command.Execute(commandingCharacter, targetCharacter);

        stateManager.subState.ChangeState(1);
    }
}
