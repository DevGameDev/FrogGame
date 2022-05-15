using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class Fly : Unit
{
    private readonly Vector2Int[] flyActionPatterns = new Vector2Int[] 
    {
        new Vector2Int (-2, 0),
        new Vector2Int (2, 0),
        new Vector2Int (0, 2),
        new Vector2Int (0, -2),
        new Vector2Int (-2, -2),
        new Vector2Int (-2, 2),
        new Vector2Int (2, -2),
        new Vector2Int (2, 2)
    };

    protected override void Start()
    {
        // Set permissions
        displayName = "Fly";
        isEnemy = true;
        isSelectable = true;
        isDamageable = true;
        canMove = true;
        canAttack = true;

        // Set Stats
        currentHealth = maxHealth = 1;
        attack = 3;
        foreach (Vector2Int pattern in flyActionPatterns) actionPatterns.Add(pattern);

        base.Start();
    }
}
