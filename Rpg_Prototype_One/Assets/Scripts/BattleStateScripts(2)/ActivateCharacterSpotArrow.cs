using UnityEngine;

public class ActivateCharacterSpotArrow : MonoBehaviour, IExitable
{
    public GameObject characterSpotArrow;
    public AllActiveBattleSpotsScript allActiveSpots;
    public bool IsArrowActive = false;

    public void ActivateArrow()
    {
        characterSpotArrow.SetActive(true);
        IsArrowActive = true;
        allActiveSpots.NotifyOnArrowActivate(transform.gameObject);
    }

    public void DeactivateArrow()
    {
        characterSpotArrow.SetActive(false);
        IsArrowActive = false;
    }

    public void OnExit()
    {
        DeactivateArrow();
    }
}
