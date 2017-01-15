using UnityEngine;

public class CharactersInBattleState : MonoBehaviour, IEnterable, IExitable
{
    public CharacterSpot[] enemySpots;
    public GameObject[] enemyPrefabs;
    private GameObject enemy;
    //public GameObject[] playerSpots;

    public void OnEnter()
    {
        setupEnemySpots();
    }

    public void OnExit()
    {
        for (int i = 0; i < enemySpots.Length; i++)
        {
            enemySpots[i].Reset();
        }
    }

    private void setupEnemySpots()
    {
        for (int i = 0; i < Random.Range(1, enemySpots.Length + 1); i++)
        {
            enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Sprite enemySprite = enemy.GetComponent<SpriteRenderer>().sprite;
            CharacterInfo enemyInfo = enemy.GetComponent<CharacterInfo>();

            enemySpots[i].Set(enemySprite, enemyInfo);
        }
    }
}
