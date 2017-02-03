using System;
using System.Collections.Generic;

public class CharacterLevelManager
{
    private int[] levelData = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int playerCurrentLevel;
    private PlayerPersistantData playerPersistantData;

    public CharacterLevelManager(PlayerPersistantData persistData)
    {
        playerPersistantData = persistData;
        playerCurrentLevel = levelData[1];
    }

    public int GetPlayerCurrentLevel()
    {
        return playerCurrentLevel;
    }

    public void CheckIfLevelUp(int curXp)
    {
        int levelCheck = playerCurrentLevel;

        for (int i = playerCurrentLevel + 1; i < levelData.Length; i++)
        {
            if (curXp >= levelData[i] * 1000)
                levelCheck = levelData[i];
        }

        if (levelCheck != playerCurrentLevel)
            playerLeveledUp(levelCheck);
    }

    private void playerLeveledUp(int newLevel)
    {
        playerCurrentLevel = newLevel;
        playerPersistantData.NotifyPlayerLeveledUp();
    }
}


