﻿using UnityEngine;

public abstract class CharacterInfo : MonoBehaviour
{
    protected int health;
    protected string characterName;
    protected int damageAmount = 10;

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
        health -= amount;
        print(characterName);
        print("Damaged!");
        print(health);

    }
}
