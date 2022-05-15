using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class Tadpole : Unit
{
    private readonly Vector2Int[] tadpoleActionPatterns = new Vector2Int[] 
    {
        new Vector2Int (-1, 0),
        new Vector2Int (1, 0),
        new Vector2Int (0, 1),
        new Vector2Int (0, -1),
        new Vector2Int (-1, -1),
        new Vector2Int (-1, 1),
        new Vector2Int (1, -1),
        new Vector2Int (1, 1)
    };

    protected override void Start()
    {
        // Set permissions
        displayName = "Tadpole";
        isSelectable = true;
        isDamageable = true;
        canMove = true;
        canAttack = true;

        // Set Stats
        currentHealth = maxHealth = 2;
        attack = 2;
        foreach (Vector2Int pattern in tadpoleActionPatterns) actionPatterns.Add(pattern);

        base.Start();
    }
}
