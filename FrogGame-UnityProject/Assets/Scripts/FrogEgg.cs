using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class FrogEgg : Unit
{
    private readonly Vector2Int[] eggActionPatterns = new Vector2Int[]
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
        displayName = "Frog Egg";
        isSelectable = true;
        isDamageable = true;
        canMove = true;
        canAttack = true;

        // Set Stats
        currentHealth = maxHealth = 1;
        attack = 1;
        foreach (Vector2Int pattern in eggActionPatterns) actionPatterns.Add(pattern);
    }

    protected override void Init()
    {
        base.Init();
    }
}
