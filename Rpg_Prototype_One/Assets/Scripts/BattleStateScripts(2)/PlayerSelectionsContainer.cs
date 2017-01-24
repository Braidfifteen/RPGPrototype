using UnityEngine;

public class PlayerSelectionsContainer : MonoBehaviour
{
    public GameObject playerCommand;
    public GameObject commandingCharacter;
    public GameObject targetCharacter;

    private ICommand command;

    public void AddCommand(GameObject command)
    {
        playerCommand = command;
        this.command = playerCommand.GetComponent<ICommand>();
    }

    public void AddCommandingCharacter(GameObject character)
    {
        commandingCharacter = character;
    }

    public void AddTargetCharacter(GameObject targCharacter)
    {
        targetCharacter = targCharacter;
        command.Execute(commandingCharacter, targetCharacter);
    }
}
