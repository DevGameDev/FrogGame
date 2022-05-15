using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class Snake : Unit
{
    private readonly Vector2Int[] snakeActionPatterns = new Vector2Int[] 
    {
        new Vector2Int (-1, -2),
        new Vector2Int (1, -2),
        new Vector2Int (-2, -1),
        new Vector2Int (-2, 1),
        new Vector2Int (-1, 2),
        new Vector2Int (1, 2),
        new Vector2Int (2, -1),
        new Vector2Int (2, 1)
    };

    protected override void Start()
    {
        // Set permissions
        displayName = "Snake";
        isEnemy = true;
        isSelectable = true;
        isDamageable = true;
        canMove = true;
        canAttack = true;

        // Set Stats
        currentHealth = maxHealth = 2;
        attack = 2;
        foreach (Vector2Int pattern in snakeActionPatterns) actionPatterns.Add(pattern);

        base.Start();
    }
}
