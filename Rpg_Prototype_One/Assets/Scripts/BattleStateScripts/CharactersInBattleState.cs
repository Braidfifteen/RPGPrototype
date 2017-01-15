using UnityEngine;

public class CharactersInBattleState : MonoBehaviour, IEnterable, IExitable
{
    public GameObject[] enemySpots;
    public Sprite[] testEnemySprites;
    private SpriteRenderer enemySprite;
    //public GameObject[] playerSpots;







    //Testing
    public GameObject[] enemyPrefabs;
    private TestCharacterSpot enemyBehavior;
    private GameObject thisEnemy;


    public void OnEnter()
    {

        //for (int i = 0; i < Random.Range(1, enemySpots.Length + 1); i++)
        //{
        //    enemySprite = enemySpots[i].GetComponent<SpriteRenderer>();
        //    enemySprite.sprite = testEnemySprites[Random.Range(0,                             testEnemySprites.Length)];
        //    enemySpots[i].SetActive(true);
        //}
        
        for (int i = 0; i < Random.Range(1, enemySpots.Length + 1); i++)
        {
            enemySprite = enemySpots[i].GetComponent<SpriteRenderer>();
            enemyBehavior = enemySpots[i].GetComponent<TestCharacterSpot>();
            thisEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            enemySprite.sprite = thisEnemy.GetComponent<SpriteRenderer>().sprite;
            enemyBehavior.enemyBehavior = thisEnemy.GetComponent<TestEnemyScript>();
            enemySpots[i].SetActive(true);
        }
    }

    public void OnExit()
    {
        //for (int i = 0; i < enemySpots.Length; i++)
        //{
        //    enemySprite = enemySpots[i].GetComponent<SpriteRenderer>();
        //    enemySprite.sprite = null;
        //    enemySpots[i].SetActive(false);
        //}

        for (int i = 0; i < enemySpots.Length; i++)
        {
            enemySpots[i].SetActive(false);
        }
    }
}
