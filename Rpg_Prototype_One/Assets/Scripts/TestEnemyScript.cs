using UnityEngine;
using System.Collections.Generic;

public abstract class TestEnemyScript : MonoBehaviour
{
    protected int Health;

    public void TestPrintHealth()
    {
        print(Health);
    }
}
