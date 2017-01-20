using UnityEngine;

public class BattleStateInput : MonoBehaviour, IInput
{
    public SelectorArrowControl arrow;

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            arrow.MoveArrow(1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            arrow.MoveArrow(-1);
        if (Input.GetKeyDown(KeyCode.Return))
            arrow.OnSelect();

        
    }
}
