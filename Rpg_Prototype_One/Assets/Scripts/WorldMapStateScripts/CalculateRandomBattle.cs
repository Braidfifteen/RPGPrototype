using UnityEngine;

public class CalculateRandomBattle : MonoBehaviour
{
    // Reference is to see when this script should be updating.
    // I would like to find a way to decouple this relationship.
    private PlayerMovement playerMovement;

    // For now I'm just going to randomly pick a number and if it matches battleNumber
    // it will start a battle
    private int battleNumber = 10;
    private int randNum = 500;
    private float timeBetweenBattles = 3.0f;
    private float battleTimer = 0.0f;

    public CalculateRandomBattle(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    public bool calculateIfRandomBattle()
    {
        if((timeForBattle() && Random.Range(0, randNum) == battleNumber &&                  playerMovement.IsMoving))
        {
            battleTimer = 0.0f;
            return true;
        }
        return false;
    }

    private bool timeForBattle()
    {
        battleTimer += Time.deltaTime;
        return (battleTimer > timeBetweenBattles);
    }
}
