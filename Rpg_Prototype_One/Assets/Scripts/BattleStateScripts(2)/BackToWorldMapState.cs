using UnityEngine;

public class BackToWorldMapState : MonoBehaviour, ILateEnter
{
    public StateParentScript stateParent;

    public void OnLateEnter()
    {
        stateParent.subState.ChangeGameState(0);
    }
    
}
