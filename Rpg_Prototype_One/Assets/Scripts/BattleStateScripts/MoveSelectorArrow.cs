using UnityEngine;
using System.Collections.Generic;
using System;

public class MoveSelectorArrow : MonoBehaviour, ILateEnter, IExitable
{
    public GameObject[] FriendlySpots;
    public GameObject[] EnemySpots;

    public List<GameObject> activeSpots = new List<GameObject>();

    private int arrowIndex;
    private int previousIndex;



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
        activateSpot();
    }

    public void OnExit()
    {
        activeSpots.Clear();
    }

    // 1 is down. -1 is up.
    public void MoveArrow(int direction)
    {
        if (direction == 1)
        {
            arrowIndex -= 1;
            handleArgumentOutOfRangeException();
            activateSpot();
        }
        else
        {
            arrowIndex += 1;
            handleArgumentOutOfRangeException();
            activateSpot();
        }
    }

    private void handleArgumentOutOfRangeException()
    {
        if (arrowIndex >= activeSpots.Count)
            arrowIndex = 0;
        else if (arrowIndex < 0)
            arrowIndex = activeSpots.Count - 1;
    }

    private void activateSpot()
    {
        try
        {
            activeSpots[previousIndex].GetComponent<ActivateSpot>().Deactivate();
        }
        catch(ArgumentOutOfRangeException)
        {
        }
        activeSpots[arrowIndex].GetComponent<ActivateSpot>().Activate();

        previousIndex = arrowIndex;
    }
}
