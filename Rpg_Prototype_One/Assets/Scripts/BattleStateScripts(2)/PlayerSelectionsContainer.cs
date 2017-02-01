using UnityEngine;

public class PlayerSelectionsContainer : MonoBehaviour
{
    public GameObject PlayerCommand;
    public GameObject CommandingCharacter;
    public GameObject TargetCharacter;

    private ICommand command;

    public ICommand GetCommand()
    {
        return command;
    }

    public void AddCommand(GameObject command)
    {
        PlayerCommand = command;
        this.command = PlayerCommand.GetComponent<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        this.command = command;
    }

    public void AddCommandingCharacter(GameObject character)
    {
        CommandingCharacter = character;
    }

    public void AddTargetCharacter(GameObject targCharacter)
    {
        TargetCharacter = targCharacter;
    }

    public void AddAll(GameObject commandCharacter, GameObject targCharacter, GameObject command)
    {
        CommandingCharacter = commandCharacter;
        TargetCharacter = targCharacter;
        PlayerCommand = command;
        this.command = PlayerCommand.GetComponent<ICommand>();
    }

    public void AddAll(GameObject commandCharacter, GameObject targCharacter, ICommand command)
    {
        CommandingCharacter = commandCharacter;
        TargetCharacter = targCharacter;
        this.command = command;
    }
}
