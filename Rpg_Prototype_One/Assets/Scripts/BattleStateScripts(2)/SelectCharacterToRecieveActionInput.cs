using UnityEngine;
using System.Collections.Generic;
using System;

public class SelectCharacterToRecieveActionInput : MonoBehaviour, IInput, IEnterable, IExitable
{
    public AllActiveBattleSpotsScript activeBattleSpots;

    private int currentIndex;

    // Will use obersever pattern instead of keeping track of previous index
    private int previousIndex;


    public void OnEnter()
    {
        currentIndex = 0;
        previousIndex = 0;
    }

    public void OnExit()
    {
        for (int i = 0; i < activeBattleSpots.AllActiveSpots.Count; i++)
            activeBattleSpots.AllActiveSpots[i].GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            moveCharacterSpotSelectorArrow(-1);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveCharacterSpotSelectorArrow(1);
    }

    // 1 is down. -1 is up
    private void moveCharacterSpotSelectorArrow(int direction)
    {
        if (direction == 1)
        {
            currentIndex -= 1;
            handleArgumentOutOfRangeException();
            activateCurrentSpot();
        }
        else
        {
            currentIndex += 1;
            handleArgumentOutOfRangeException();
            activateCurrentSpot();
        }

    }

    private void handleArgumentOutOfRangeException()
    {
        if (currentIndex >= activeBattleSpots.AllActiveSpots.Count)
            currentIndex = 0;
        else if (currentIndex < 0)
            currentIndex = activeBattleSpots.AllActiveSpots.Count - 1;
    }

    private void activateCurrentSpot()
    {
        try
        {
            activeBattleSpots.AllActiveSpots[previousIndex].GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        activeBattleSpots.AllActiveSpots[currentIndex].GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();

        previousIndex = currentIndex;
    }
}
