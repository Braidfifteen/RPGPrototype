using UnityEngine;

public class AttackOptionCommand : MonoBehaviour, ICommand
{
    public void Execute(GameObject commandChar, GameObject targChar)
    {
        CharacterInfo commandCharacter = commandChar.GetComponent<CharacterSpot>().GetCharacterInfo();
        CharacterInfo targetCharacter = targChar.GetComponent<CharacterSpot>().GetCharacterInfo();
        commandCharacter.Attack(targetCharacter);
    }
}
