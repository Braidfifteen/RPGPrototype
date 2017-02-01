using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool IsPlayerTurn = true;

    public void ChangeTurn()
    {
        IsPlayerTurn = !IsPlayerTurn;
    }
}
