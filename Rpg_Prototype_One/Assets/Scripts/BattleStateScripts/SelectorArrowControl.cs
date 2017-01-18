using UnityEngine;
using System.Collections.Generic;
using System;

public class SelectorArrowControl : MonoBehaviour, ILateEnter, IExitable, ISelectable
{
    public GameObject[] FriendlySpots;
    public GameObject[] EnemySpots;

    public List<GameObject> activeSpots = new List<GameObject>();

    private int currentIndex;
    private int previousIndex;



    public void OnLateEnter()
    {
        currentIndex = 0;
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
            currentIndex -= 1;
            handleArgumentOutOfRangeException();
            activateSpot();
        }
        else
        {
            currentIndex += 1;
            handleArgumentOutOfRangeException();
            activateSpot();
        }
    }

    public void OnSelect()
    {
        activeSpots[currentIndex].GetComponent<CharacterSpot>().OnSelect();
    }

    private void handleArgumentOutOfRangeException()
    {
        if (currentIndex >= activeSpots.Count)
            currentIndex = 0;
        else if (currentIndex < 0)
            currentIndex = activeSpots.Count - 1;
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
        activeSpots[currentIndex].GetComponent<ActivateSpot>().Activate();

        previousIndex = currentIndex;
    }
}
