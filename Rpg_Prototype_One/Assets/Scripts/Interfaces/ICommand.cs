using UnityEngine;

public interface ICommand
{
    void Execute(GameObject commandCharacter, GameObject targCharacter);
}
