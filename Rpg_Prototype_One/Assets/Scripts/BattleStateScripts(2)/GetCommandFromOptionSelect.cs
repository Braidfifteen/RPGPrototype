using UnityEngine;

public class GetCommandFromOptionSelect : MonoBehaviour
{
    public PlayerSelectionsContainer playerSelectionsContainer;
    public GameObject returnedObject;
    public bool isSelected;

    public void SetSelected(bool isSelected)
    {
        this.isSelected = isSelected;

        if (this.isSelected)
        {
            playerSelectionsContainer.AddCommand(returnedObject);
        }
    }
    
}
