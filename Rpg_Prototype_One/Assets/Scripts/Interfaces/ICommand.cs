using UnityEngine;

public interface ICommand
{
    void Execute(GameObject commandCharacter, GameObject targCharacter);
    void UpdateCommand();
    bool IsUpdating();
    void SetObject(object obj);
}
