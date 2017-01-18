using UnityEngine;

public abstract class CharacterInfo : MonoBehaviour
{
    protected int health;
    protected string characterName;

    public string GetName()
    {
        return characterName;
    }

    public int GetHealth()
    {
        return health;
    }
}
