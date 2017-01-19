using UnityEngine;

public class SelectActionStateInput : MonoBehaviour, IInput, IEnterable
{
    public GameObject[] selectableOptions;

    private int currentOptionIndex = 0;
    private int previousOptionIndex = 0;

    public void OnEnter()
    {
        selectableOptions[0].SetActive(true);
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
    }

    // -1 up, 1 down
    private void changeSelectedOption(int direction)
    {
        previousOptionIndex = currentOptionIndex;
        switch(direction)
        {
            case -1:
                if (!(currentOptionIndex >= selectableOptions.Length))
                    currentOptionIndex += 1;
                break;
            case 1:
                if (!(currentOptionIndex <= 0))
                    currentOptionIndex -= 1;
                break;
        }
        if (!(previousOptionIndex == currentOptionIndex))
        {
            selectableOptions[previousOptionIndex].SetActive(false);
            selectableOptions[currentOptionIndex].SetActive(true);
        }
    }
}
