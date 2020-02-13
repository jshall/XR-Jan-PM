using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Player
{
    public static float HitPoints { get; private set; }
    public static float MaxHitPoints { get; private set; } = 100;

    static Player()
    {
        HitPoints = MaxHitPoints;
    }

    public static void Attack(float damage)
    {
        HitPoints -= damage;
    }
}
