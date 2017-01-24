using UnityEngine;
using System.Collections.Generic;

public class AllActiveBattleSpotsScript : MonoBehaviour
{
    private List<GameObject> allActiveSpots = new List<GameObject>();

    public GameObject PlayerPartyOneSpot;
    public GameObject EnemyMiddleSpot;
    private int enemyMiddleSpotIndex = -1;
    private int playerPartyOneIndex = -1;

    public int EnemyMiddleSpotIndex
    {
        get
        {
            if (enemyMiddleSpotIndex == -1)
            {
                for (int i = 0; i < allActiveSpots.Count; i++)
                {
                    if (allActiveSpots[i] == EnemyMiddleSpot)
                        enemyMiddleSpotIndex = i;
                }
            }
            return enemyMiddleSpotIndex;
        }
    }

    public List<GameObject> AllActiveSpots { get { return allActiveSpots; } }

    public void NotifyOnActivatedDeactivateGameObject(GameObject theGameObject)
    {
        if (theGameObject.activeInHierarchy)
            allActiveSpots.Add(theGameObject);
        else if (!theGameObject.activeInHierarchy)
            allActiveSpots.Remove(theGameObject);
    }


}
