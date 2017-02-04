using UnityEngine;

public abstract class CharacterInfo : MonoBehaviour
{
    protected int health;
    protected string characterName;
    protected int damageAmount = 10;
    protected CharacterSpotScript currentSpot;
    protected int xpReturn = 3000;
    protected int lastTakenDamageAmount;

    public void SetCurrentSpot(CharacterSpotScript spot)
    {
        currentSpot = spot;
    }

    public string GetName()
    {
        return characterName;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Attack(CharacterInfo c)
    {
        print(characterName);
        print("Attacked!");
        c.Damage(damageAmount);
    }

    public void Damage(int amount)
    {
        lastTakenDamageAmount = amount;
        health -= amount;
        print(characterName);
        print("Damaged!");
        print(health);
        checkIfDead();
    }

    public int GetLastTakenDamageAmount()
    {
        return lastTakenDamageAmount;
    }

    public Vector3 GetCurrentSpotLocation()
    {
        return currentSpot.GetSpotVector3();
    }

    public virtual int XPReturn()
    {
        return xpReturn;
    }

    private void checkIfDead()
    {
        if (health <= 0)
            currentSpot.CharacterDied();
    }
}
