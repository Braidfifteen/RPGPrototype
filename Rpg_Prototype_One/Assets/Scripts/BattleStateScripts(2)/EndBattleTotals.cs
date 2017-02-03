using UnityEngine;

public class EndBattleTotals : MonoBehaviour, IEarlyEnter
{
    public GainedItemsAndXP itemsAndXP;

    public void OnEarlyEnter()
    {
        itemsAndXP.EndBattleTotals();
    }
}
