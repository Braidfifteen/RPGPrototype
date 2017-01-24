using UnityEngine;

public class ResetBattleSpots : MonoBehaviour, IExitable, IEnterable, IEarlyEnter
{
    public GameObject[] enemyBattleSpots;
    public GameObject[] playerPartyBattleSpots;
    public bool resetOnEnter = false;
    public bool resetOnExit = false;
    public bool resetOnEarlyEnter = false;
    public bool resetEnemySpots = true;
    public bool resetplayerPartySpots = false;

    public void OnEnter()
    {
        if (resetOnEnter)
        {
            if (resetEnemySpots)
                resetEnemy();
            if (resetplayerPartySpots)
                resetPlayerParty();
        }
    }
   
    public void OnEarlyEnter()
    {
        if (resetOnEarlyEnter)
        {
            if (resetEnemySpots)
                resetEnemy();
            if (resetplayerPartySpots)
                resetPlayerParty();
        }
    }

    public void OnExit()
    {
        if (resetOnExit)
        {
            if (resetEnemySpots)
                resetEnemy();
            if (resetplayerPartySpots)
                resetPlayerParty();
        }
    }

    private void resetEnemy()
    {
        for (int i = 0; i < enemyBattleSpots.Length; i++)
        {
            enemyBattleSpots[i].GetComponent<CharacterSpotScript>().Reset();
        }
    }

    private void resetPlayerParty()
    {
        for (int i = 0; i < playerPartyBattleSpots.Length; i++)
        {
            playerPartyBattleSpots[i].GetComponent<CharacterSpotScript>().Reset();
        }
    }
}
