using UnityEngine;

public class CharacterBattleSpotActivateDeactivateGameObject : MonoBehaviour
{
    public AllActiveBattleSpotsScript allActiveBattleSpots;
    public DestroyGameObject destroyGameObjectObserver;

    public void ActivateBattleSpotGameObject()
    {
        transform.gameObject.SetActive(true);
        allActiveBattleSpots.NotifyOnActivatedDeactivateGameObject(transform.gameObject);
    }

    public void DeactivateBattleSpotGameObject()
    {
        if (destroyGameObjectObserver != null)
            destroyGameObjectObserver.Destroy();
        transform.gameObject.SetActive(false);
        allActiveBattleSpots.NotifyOnActivatedDeactivateGameObject(transform.gameObject);
    }

    public void SetDestroyObjectObserver(DestroyGameObject observer)
    {
        destroyGameObjectObserver = observer;
    }
}
