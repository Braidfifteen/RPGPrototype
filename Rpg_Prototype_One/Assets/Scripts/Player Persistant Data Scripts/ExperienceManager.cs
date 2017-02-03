
public class ExperienceManager
{
    private int playerCurrentExperience = 0;
    private CharacterLevelManager characterLevelManager;
    private PlayerPersistantData playerPersistantData;

    public ExperienceManager(CharacterLevelManager levelManager, PlayerPersistantData persistData)
    {
        playerPersistantData = persistData;
        characterLevelManager = levelManager;
    }

    public int GetPlayerCurrentExperience()
    {
        return playerCurrentExperience;
    }

    public void AddExperience(int experience)
    {
        playerCurrentExperience += experience;
        characterLevelManager.CheckIfLevelUp(playerCurrentExperience);
        playerPersistantData.NotifyOnNewXPGain();
    }
}
