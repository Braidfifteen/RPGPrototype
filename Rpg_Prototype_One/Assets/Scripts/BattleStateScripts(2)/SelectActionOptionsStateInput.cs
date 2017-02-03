using UnityEngine;
using System;

public class SelectActionOptionsStateInput : MonoBehaviour, IInput, IEnterable, IExitable
{
    public SubStateMachine battleStateManager;
    public PlayerSelectionsContainer playerSelections;
    public AllActiveBattleSpotsScript activeBattleSpots;

    public AttackingPlayerSelectedCheck attackingPlayerSelectedCheck;
    public GameObject[] selectableOptions;

    private int currentOptionIndex = 0;

    // Will use observer pattern instead of keeping track of previous index
    private int previousOptionIndex = 0;

    public void OnEnter()
    {
        selectableOptions[0].SetActive(true);
        //if (!playerSelections.CommandingCharacter.GetComponent<ActivateCharacterSpotArrow>().IsArrowActive)
        //    playerSelections.CommandingCharacter.GetComponent<ActivateCharacterSpotArrow>().ActivateArrow();
        ActivateCharacterSpotArrow playerArrow = activeBattleSpots.PlayerPartyOneSpot.GetComponent<ActivateCharacterSpotArrow>();

        if (!playerArrow.IsArrowActive)
            playerArrow.ActivateArrow();
    }

    public void OnExit()
    {
        for (int i = 0; i < selectableOptions.Length; i++)
            selectableOptions[i].transform.gameObject.SetActive(false);
    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeSelectedOption(-1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeSelectedOption(1);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            selectableOptions[currentOptionIndex].GetComponent<GetCommandFromOptionSelect>().SetSelected(true);
            attackingPlayerSelectedCheck.AttackingPlayerIsSelected = true;
            battleStateManager.ChangeState(2);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            attackingPlayerSelectedCheck.AttackingPlayerIsSelected = false;
            battleStateManager.ChangeState(2);
        }

    }

    // -1 up, 1 down
    private void changeSelectedOption(int direction)
    {
        if (direction == -1)
        {
            currentOptionIndex += 1;
            handleIndexOutOfRangeException();
            selectOption();
        }
        else if (direction == 1)
        {
            currentOptionIndex -= 1;
            handleIndexOutOfRangeException();
            selectOption();
        }

    }

    private void handleIndexOutOfRangeException()
    {
        if (currentOptionIndex >= selectableOptions.Length)
            currentOptionIndex = selectableOptions.Length - 1;
        else if (currentOptionIndex < 0)
            currentOptionIndex = 0;
    }

    private void selectOption()
    {
        try
        {
            selectableOptions[previousOptionIndex].SetActive(false);
        }
        catch(IndexOutOfRangeException)
        { }

        selectableOptions[currentOptionIndex].SetActive(true);

        previousOptionIndex = currentOptionIndex;
    }
}
