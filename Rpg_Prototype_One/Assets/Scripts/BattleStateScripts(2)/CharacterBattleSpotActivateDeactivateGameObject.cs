using UnityEngine;

public class CharacterBattleSpotActivateDeactivateGameObject : MonoBehaviour
{
    public AllActiveBattleSpotsScript allActiveBattleSpots;

    public void ActivateBattleSpotGameObject()
    {
        transform.gameObject.SetActive(true);
        allActiveBattleSpots.NotifyOnActivatedDeactivateGameObject(transform.gameObject);
    }

    public void DeactivateBattleSpotGameObject()
    {
        transform.gameObject.SetActive(false);
        allActiveBattleSpots.NotifyOnActivatedDeactivateGameObject(transform.gameObject);
    }
}
