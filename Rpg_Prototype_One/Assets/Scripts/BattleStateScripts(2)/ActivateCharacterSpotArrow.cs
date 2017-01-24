using UnityEngine;

public class ActivateCharacterSpotArrow : MonoBehaviour, IExitable
{
    public GameObject characterSpotArrow;

    public void ActivateArrow()
    {
        characterSpotArrow.SetActive(true);
    }

    public void DeactivateArrow()
    {
        characterSpotArrow.SetActive(false);
    }

    public void OnExit()
    {
        DeactivateArrow();
    }
}
