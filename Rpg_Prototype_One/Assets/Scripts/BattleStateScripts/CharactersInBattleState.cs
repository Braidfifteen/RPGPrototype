using UnityEngine;

public class CharactersInBattleState : MonoBehaviour, IEnterable, IExitable
{
    public GameObject[] enemySpots;
    //public GameObject[] playerSpots;

    public Sprite[] testEnemySprites;

    private SpriteRenderer enemeySprite;


    public void OnEnter()
    {
        for (int i = 0; i < Random.Range(1, enemySpots.Length + 1); i++)
        {
            enemeySprite = enemySpots[i].GetComponent<SpriteRenderer>();
            enemeySprite.sprite = testEnemySprites[Random.Range(0, testEnemySprites.Length)];
            enemySpots[i].SetActive(true);
        }
    }

    public void OnExit()
    {
        for (int i = 0; i < enemySpots.Length; i++)
        {
            enemeySprite = enemySpots[i].GetComponent<SpriteRenderer>();
            enemeySprite.sprite = null;
            enemySpots[i].SetActive(false);
        }
    }
}
