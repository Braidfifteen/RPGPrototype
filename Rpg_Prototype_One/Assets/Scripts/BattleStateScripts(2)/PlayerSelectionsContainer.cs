using UnityEngine;

public class PlayerSelectionsContainer : MonoBehaviour
{
    public GameObject PlayerCommand;
    public GameObject CommandingCharacter;
    public GameObject TargetCharacter;

    private ICommand command;

    public void AddCommand(GameObject command)
    {
        PlayerCommand = command;
        this.command = PlayerCommand.GetComponent<ICommand>();
    }

    public void AddCommandingCharacter(GameObject character)
    {
        CommandingCharacter = character;
    }

    public void AddTargetCharacter(GameObject targCharacter)
    {
        TargetCharacter = targCharacter;
        command.Execute(CommandingCharacter, TargetCharacter);
    }
}
