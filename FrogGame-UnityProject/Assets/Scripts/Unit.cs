using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Basic Unit Info
    string displayName;
    int _health; // Always defined, but no interaction for non-damageable units
    int _attack; // Always defined, but no interaction for non-agressive units
    // Tile2D tile;

    (int, int)[] movementPatterns;

    public bool isEnemy = false;

    void Start()
    {
        Debug.Log($"Start - Unit: {displayName}");
    }

    void Update()
    {
        UpdateInfo();
    }

    void UpdateInfo() 
    {
        //Grid2D grid = Object.FindObjectOfType<GRIDSCRIPTNAME>();
        //int[] = tile.ReturnPosition();
    }
}
