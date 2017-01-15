using UnityEngine;

public interface IState
{
    void OnUpdate();
    void OnEnter();
    void OnExit();
    void HandleInput();
}
