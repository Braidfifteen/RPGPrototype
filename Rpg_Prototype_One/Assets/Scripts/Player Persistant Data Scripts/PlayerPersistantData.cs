using UnityEngine;
using System;

public class PlayerPersistantData : MonoBehaviour
{
    private CharacterLevelManager playerLevel;
    private ExperienceManager playerExperience;

    public PlayerPersistantData()
    {
        playerLevel = new CharacterLevelManager(this);
        playerExperience = new ExperienceManager(playerLevel, this);
    }

    public void NotifyPlayerLeveledUp()
    {
        string str = string.Format("Player Leveled up! Current Level: {0}.", playerLevel.GetPlayerCurrentLevel());
        print(str);
    }

    public void NotifyOnNewXPGain()
    {
        string str = string.Format("Player Experience: {0}.", playerExperience.GetPlayerCurrentExperience());
        print(str);
    }

    public void AddExperience(int gainedXP)
    {
        playerExperience.AddExperience(gainedXP);
    }
}
