using UnityEngine;

public class AttackOptionCommand : MonoBehaviour, ICommand
{
    private BattleDamageNumbersManager battleDamageNumbers;
    private bool isUpdating = false;
    private CharacterInfo commandCharacter;
    private CharacterInfo targetCharacter;

    public void SetObject(object obj)
    {
        battleDamageNumbers = (BattleDamageNumbersManager)obj;
    }

    public void Execute(GameObject commandChar, GameObject targChar)
    {
        commandCharacter = commandChar.GetComponent<CharacterSpotScript>().GetCharacterInfo();
        targetCharacter = targChar.GetComponent<CharacterSpotScript>().GetCharacterInfo();
        commandCharacter.Attack(targetCharacter);
        battleDamageNumbers.SetUpDamageNumbers(targetCharacter.GetLastTakenDamageAmount(), targetCharacter.GetCurrentSpotLocation());
    }

    public void UpdateCommand()
    {
        battleDamageNumbers.Updating();
        isUpdating = battleDamageNumbers.IsUpdating();
    }

    public bool IsUpdating()
    {
        return isUpdating;
    }
}
