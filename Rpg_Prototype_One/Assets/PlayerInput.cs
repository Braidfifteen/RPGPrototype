using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    public PlayerMovement objectMoved;

    private float moveVert;
    private float moveHorz;

    public void GetInput()
    {
        moveVert = Input.GetAxis("Vertical");
        moveHorz = Input.GetAxis("Horizontal");

        objectMoved.Move(moveVert, moveHorz);
    }

    public void Update()
    {
        GetInput();
    }
}
