using UnityEngine;


// These coordinates are hard coded through the inspector.
// Should be changed to as to allow for variations.
public class CoordsForSelectorArrow : MonoBehaviour
{
    public float xCoord;
    public float yCoord;

    public Vector3 GetCoordinates()
    {
        return new Vector3(xCoord, yCoord, 0);
    }
}
