using UnityEngine;
using System.Collections.Generic;
using System;

public class MoveSelectorArrow : MonoBehaviour, ILateEnter, IExitable
{
    public GameObject[] FriendlySpots;
    public GameObject[] EnemySpots;
    public GameObject SelectorArrow;

    public List<GameObject> activeSpots = new List<GameObject>();
    public int arrowIndex;



    public void OnLateEnter()
    {
        arrowIndex = 0;
        for (int i = 0; i < FriendlySpots.Length; i++)
        {
            if (FriendlySpots[i].activeInHierarchy)
            {
                activeSpots.Add(FriendlySpots[i]);
            }
        }

        for (int i = 0; i < EnemySpots.Length; i++)
        {
            if (EnemySpots[i].activeInHierarchy)
            {
                activeSpots.Add(EnemySpots[i]);
            }
        }
        setArrow(activeSpots[arrowIndex].GetComponent<CoordsForSelectorArrow>().GetCoordinates());

        SelectorArrow.SetActive(true);
    }

    public void OnExit()
    {
        activeSpots.Clear();
        SelectorArrow.SetActive(false);
    }

    private void setArrow(Vector3 pos)
    {
        SelectorArrow.transform.position = pos;
        SelectorArrow.transform.rotation = Quaternion.identity;
    }

    // 1 is down. -1 is up.
    public void MoveArrow(int direction)
    {
        if (direction == 1)
        {
            arrowIndex -= 1;
            handleArgumentOutOfRangeException();
            setArrow(activeSpots[arrowIndex].GetComponent<CoordsForSelectorArrow>().GetCoordinates());
        }
        else
        {
            arrowIndex += 1;
            handleArgumentOutOfRangeException();
            setArrow(activeSpots[arrowIndex].GetComponent<CoordsForSelectorArrow>().GetCoordinates());
        }
    }

    private void handleArgumentOutOfRangeException()
    {
        if (arrowIndex >= activeSpots.Count)
            arrowIndex = 0;
        else if (arrowIndex < 0)
            arrowIndex = activeSpots.Count - 1;

    }
}
