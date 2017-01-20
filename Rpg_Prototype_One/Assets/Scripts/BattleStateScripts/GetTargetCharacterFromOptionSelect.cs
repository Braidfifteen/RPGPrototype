using UnityEngine;

public class GetTargetCharacterFromOptionSelect : MonoBehaviour
{
    public PlayerSelectionsContainer playerSelectionsContainer;
    public GameObject returnObject;
    public bool isSelected;

    public void SetSelected(bool isSelected)
    {
        this.isSelected = isSelected;

        if (this.isSelected)
        {
            playerSelectionsContainer.AddTargetCharacter(returnObject);
        }
    }
}
