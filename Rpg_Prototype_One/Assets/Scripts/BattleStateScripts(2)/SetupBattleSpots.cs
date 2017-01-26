using UnityEngine;
using System.Collections.Generic;

// This script will be attached to Battle State Enter gameObject. It inits the character spots for the battle.
public class SetupBattleSpots : MonoBehaviour, IEnterable, IExitable
{
    public PlayerSelectionsContainer PlayerSelections;
    public GameObject[] playerPartySpots;
    public CharacterSpotScript[] enemyCharacterSpots;
    public CharacterSpotScript[] playerPartyCharacterSpots;
    public GameObject[] enemyGameObjectSpots;

    // This list of enemy prefabs will eventually come from a region class which will have different enemies
    // depending on the region.
    public GameObject[] enemyPrefabs;
    public GameObject[] playerPartyPrefabs;

    private List<GameObject> activeSpots = new List<GameObject>();

    // This script is ISubject
    private int currentIndex;

    public List<GameObject> ActiveSpots { get { return activeSpots; } }

    public void OnEnter()
    {
        setupEnemySpots();
        setupPlayerSpots();
        PlayerSelections.CommandingCharacter.GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
    }

    public void OnExit()
    {
        activeSpots.Clear();
    }

    // This method is called in OnEnter(), BEFORE getActiveSpots() which is called in OnLateEnter()
    // Finding the enemey/player party count activates only the necessary spots, which getActiveSpots()
    // puts into a list.
    private void setupEnemySpots()
    {
        for (int i = 0; i < Random.Range(1, enemyCharacterSpots.Length + 1); i++)
        {
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Sprite enemySprite = enemy.GetComponent<SpriteRenderer>().sprite;
            CharacterInfo enemyInfo = enemy.GetComponent<CharacterInfo>();

            enemyCharacterSpots[i].Set(enemySprite, enemyInfo, i);
        }
    }

    private void setupPlayerSpots()
    {
        for (int i = 0; i < playerPartySpots.Length; i++)
        {
            GameObject player = playerPartyPrefabs[0];
            Sprite playerSprite = player.GetComponent<SpriteRenderer>().sprite;
            CharacterInfo playerInfo = player.GetComponent<CharacterInfo>();

            playerPartyCharacterSpots[i].Set(playerSprite, playerInfo, i);
        }
    }
}
