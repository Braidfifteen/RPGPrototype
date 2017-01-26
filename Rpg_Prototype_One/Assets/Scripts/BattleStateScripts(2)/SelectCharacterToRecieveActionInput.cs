using UnityEngine;
using System.Collections.Generic;
using System;

public class SelectCharacterToRecieveActionInput : MonoBehaviour, IInput, IEnterable, IExitable
{
    public SubStateMachine battleStateManager;

    public AllActiveBattleSpotsScript activeBattleSpots;
    public PlayerSelectionsContainer playerSelections;
    public AttackingPlayerSelectedCheck attackingPlayerSelectedCheck;

    private int currentIndex;

    // Will use obersever pattern instead of keeping track of previous index
    private int previousIndex;


    public void OnEnter()
    {
        if (attackingPlayerSelectedCheck.AttackingPlayerIsSelected)
        {
            currentIndex = 0;
            playerSelections.CommandingCharacter.GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
            activeBattleSpots.AllActiveSpots[currentIndex].GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
        }
        else
        {
            //currentIndex = 0;
            //if (!activeBattleSpots.AllActivePlayerSpots[currentIndex].GetComponent<ActivateCharacterSpotArrow>().IsArrowActive)
            //    activeBattleSpots.AllActivePlayerSpots[currentIndex].GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
            for (int i = 0; i < activeBattleSpots.AllActivePlayerSpots.Count; i++)
            {
                if (activeBattleSpots.AllActivePlayerSpots[i] == playerSelections.CommandingCharacter)
                {
                    currentIndex = i;
                    if (!activeBattleSpots.AllActivePlayerSpots[i].GetComponent<ActivateCharacterSpotArrow>().IsArrowActive)
                        activeBattleSpots.AllActivePlayerSpots[i].GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
                }
                else
                {
                    if (activeBattleSpots.AllActivePlayerSpots[i].GetComponent<ActivateCharacterSpotArrow>().IsArrowActive)
                        activeBattleSpots.AllActivePlayerSpots[i].GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
                }
            }
        }
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
        if (Input.GetKeyDown(KeyCode.Backspace))
            battleStateManager.ChangeState(1);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (attackingPlayerSelectedCheck.AttackingPlayerIsSelected)
                addEnemyToRecieveActionToSelectionsList();
            else
            {
                addCommandingCharacterToSelectionsList();
                battleStateManager.ChangeState(1);
            }
        }





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
        if (attackingPlayerSelectedCheck.AttackingPlayerIsSelected)
        {
            if (currentIndex >= activeBattleSpots.AllActiveSpots.Count)
                currentIndex = 0;
            else if (currentIndex < 0)
                currentIndex = activeBattleSpots.AllActiveSpots.Count - 1;
        }
        else
        {
            if (currentIndex >= activeBattleSpots.AllActivePlayerSpots.Count)
                currentIndex = 0;
            else if (currentIndex < 0)
                currentIndex = activeBattleSpots.AllActivePlayerSpots.Count - 1;
        }
    }

    private void activateCurrentSpot()
    {
        if (attackingPlayerSelectedCheck.AttackingPlayerIsSelected)
        {
            try
            {
                activeBattleSpots.AllActiveSpots[previousIndex].GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            activeBattleSpots.AllActiveSpots[currentIndex].GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
        }
        else
        {
            try
            {
                activeBattleSpots.AllActivePlayerSpots[previousIndex].GetComponent<ActivateCharacterSpotArrow>().DeactivateArrow();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            activeBattleSpots.AllActivePlayerSpots[currentIndex].GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
        }

        previousIndex = currentIndex;
    }

    private void addEnemyToRecieveActionToSelectionsList()
    {
        playerSelections.AddTargetCharacter(activeBattleSpots.AllActiveSpots[currentIndex]);
    }

    private void addCommandingCharacterToSelectionsList()
    {
        playerSelections.AddCommandingCharacter(activeBattleSpots.AllActivePlayerSpots[currentIndex]);
    }
}
