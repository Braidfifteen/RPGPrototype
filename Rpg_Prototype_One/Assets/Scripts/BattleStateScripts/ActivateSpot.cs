using UnityEngine;

public class ActivateSpot : MonoBehaviour, IExitable
{
    public GameObject selectorArrow;

    public void Activate()
    {
        selectorArrow.SetActive(true);
    }

    public void Deactivate()
    {
        selectorArrow.SetActive(false);
    }

    public void OnExit()
    {
        Deactivate();
    }
}
