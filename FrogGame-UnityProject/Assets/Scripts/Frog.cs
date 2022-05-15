using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class Frog : Unit 
{
    private readonly Vector2Int[] frogActionPatterns = new Vector2Int[] 
    {
        new Vector2Int (-2, 0),
        new Vector2Int (2, 0),
        new Vector2Int (0, 2),
        new Vector2Int (0, -2),
        new Vector2Int (-1, -1),
        new Vector2Int (-1, 1),
        new Vector2Int (1, -1),
        new Vector2Int (1, 1)
    };

    protected override void Start()
    {
        // Set permissions
        displayName = "Frog";
        isSelectable = true;
        isDamageable = true;
        canMove = true;
        canAttack = true;

        // Set Stats
        currentHealth = maxHealth = 3;
        attack = 2;
        foreach (Vector2Int pattern in frogActionPatterns) actionPatterns.Add(pattern);

        base.Start();
    }
}