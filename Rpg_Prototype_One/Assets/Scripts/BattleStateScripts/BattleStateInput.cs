using UnityEngine;

public class BattleStateInput : MonoBehaviour, IInput
{
    public MoveSelectorArrow arrow;

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            arrow.MoveArrow(1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            arrow.MoveArrow(-1);

        
    }
}
