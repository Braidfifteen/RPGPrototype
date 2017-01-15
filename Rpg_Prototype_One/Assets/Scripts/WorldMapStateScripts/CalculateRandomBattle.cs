using UnityEngine;

public class CalculateRandomBattle : MonoBehaviour
{
    // Reference is to see when this script should be updating.
    // I would like to find a way to decouple this relationship.
    private PlayerMovement playerMovement;

    // For now I'm just going to randomly pick a number and if it matches battleNumber
    // it will start a battle
    private int battleNumber = 10;

    public CalculateRandomBattle(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    public bool calculateIfRandomBattle()
    {
        int rand = Random.Range(0, 100);
        //print(rand);
        print(playerMovement.IsMoving);
        return (playerMovement.IsMoving && rand == battleNumber);
    }
}
