using UnityEngine;
using System.Collections.Generic;

public class AllActiveBattleSpotsScript : MonoBehaviour
{
    private List<GameObject> allActiveSpots = new List<GameObject>();
    private List<GameObject> allActiveEnemySpots = new List<GameObject>();
    private List<GameObject> allActivePlayerSpots = new List<GameObject>();

    public GameObject PlayerPartyOneSpot;
    public GameObject EnemyMiddleSpot;

    public List<GameObject> AllActiveSpots { get { return allActiveSpots; } }
    public List<GameObject> AllActiveEnemySpots { get { return allActiveEnemySpots; } }
    public List<GameObject> AllActivePlayerSpots { get { return allActivePlayerSpots; } }

    public void NotifyOnActivatedDeactivateGameObject(GameObject theGameObject)
    {
        if (theGameObject.activeInHierarchy)
        {
            allActiveSpots.Add(theGameObject);
            if (theGameObject.GetComponent<CharacterSpotScript>().IsPlayerPartySpot)
                allActivePlayerSpots.Add(theGameObject);
            else
                allActiveEnemySpots.Add(theGameObject);
        }

        else if (!theGameObject.activeInHierarchy)
        {
            allActiveSpots.Remove(theGameObject);
            if (theGameObject.GetComponent<CharacterSpotScript>().IsPlayerPartySpot)
                allActivePlayerSpots.Remove(theGameObject);
            else
            {
                allActiveEnemySpots.Remove(theGameObject);
            }

        }
    }

    public void NotifyOnArrowActivate(GameObject theGameObject)
    {
        for (int i = 0; i < allActiveSpots.Count; i++)
        {
            if (allActiveSpots[i] != theGameObject)
                allActiveSpots[i].GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
        }
    }
}