using UnityEngine;

// This is just for moving the arrow. Should change class name.
public class ActivateSpot : MonoBehaviour, IExitable
{
    public GameObject selectable;

    public void Activate()
    {
        selectable.SetActive(true);
    }

    public void Deactivate()
    {
        selectable.SetActive(false);
    }

    public void OnExit()
    {
        Deactivate();
    }
}
