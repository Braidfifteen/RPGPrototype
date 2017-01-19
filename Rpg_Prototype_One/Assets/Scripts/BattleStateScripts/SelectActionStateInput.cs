using UnityEngine;
using System;

public class SelectActionStateInput : MonoBehaviour, IInput, IEnterable, IExitable
{
    public GameObject[] selectableOptions;
    public SubStateMachine subState;

    private int currentOptionIndex = 0;
    private int previousOptionIndex = 0;

    public void OnEnter()
    {
        selectableOptions[0].SetActive(true);
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

        // For Testing
        if (Input.GetKeyDown(KeyCode.Return))
        {
            subState.ChangeGameState(0);
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
