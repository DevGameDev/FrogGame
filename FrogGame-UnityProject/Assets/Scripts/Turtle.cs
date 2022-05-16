using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class Turtle : Unit
{
    private readonly Vector2Int[] turtleActionPatterns = new Vector2Int[] 
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
        displayName = "Turtle";
        isEnemy = true;
        isSelectable = true;
        isDamageable = true;
        canMove = true;
        canAttack = true;

        // Set Stats
        currentHealth = maxHealth = 4;
        attack = 2;
        foreach (Vector2Int pattern in turtleActionPatterns) actionPatterns.Add(pattern);
    }

    protected override void Init()
    {
        base.Init();
    }
}
