using UnityEngine;
using System.Collections.Generic;

public class AllActiveBattleSpotsScript : MonoBehaviour
{
    private List<GameObject> allActiveSpots = new List<GameObject>();

    public int activeCount;
    public List<GameObject> AllActiveSpots { get { return allActiveSpots; } }

    public void NotifyOnActivatedDeactivateGameObject(GameObject theGameObject)
    {
        if (theGameObject.activeInHierarchy)
            allActiveSpots.Add(theGameObject);
        else if (!theGameObject.activeInHierarchy)
            allActiveSpots.Remove(theGameObject);
        activeCount = allActiveSpots.Count;
    }



}
