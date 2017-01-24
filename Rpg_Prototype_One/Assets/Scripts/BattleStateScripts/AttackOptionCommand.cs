using UnityEngine;

public class AttackOptionCommand : MonoBehaviour, ICommand
{
    public void Execute(GameObject commandChar, GameObject targChar)
    {
        CharacterInfo commandCharacter = commandChar.GetComponent<CharacterSpotScript>().GetCharacterInfo();
        CharacterInfo targetCharacter = targChar.GetComponent<CharacterSpotScript>().GetCharacterInfo();
        commandCharacter.Attack(targetCharacter);
    }
}
