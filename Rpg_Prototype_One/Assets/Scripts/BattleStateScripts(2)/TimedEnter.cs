﻿using UnityEngine;

public class TimedEnter : MonoBehaviour, IUpdatable
{
    public SubStateMachine battleStateManager;

    private float counter = 0.0f;
    private float stateDuration = 3.0f;

    public void OnUpdate()
    {
        counter += Time.deltaTime;

        if (counter >= stateDuration)
        {
            counter = 0.0f;
            battleStateManager.ChangeState(1);
        }
    }
}