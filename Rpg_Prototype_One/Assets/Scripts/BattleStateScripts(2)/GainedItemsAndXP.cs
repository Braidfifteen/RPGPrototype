using UnityEngine;

public class GainedItemsAndXP : MonoBehaviour
{
    public PlayerPersistantData playerPersistantData;

    private int gainedXP = 0;

    public void AddXP(int xp)
    {
        gainedXP += xp;
    }

    public void Reset()
    {
        gainedXP = 0;
    }

    public void EndBattleTotals()
    {
        playerPersistantData.AddExperience(gainedXP);

        // Doing this instead of calling reset while this class just handles xp for one character.
        gainedXP = 0;
    }
}
