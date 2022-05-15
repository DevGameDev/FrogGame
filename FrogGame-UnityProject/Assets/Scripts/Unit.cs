using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Basic Unit Info
    string displayName;
    public bool isEnemy = false;
    int _health; // Always defined, but no interaction for non-damageable units
    int _attack; // Always defined, but no interaction for non-agressive units

    Tile tile; // Tile Parent

    public Vector2Int[] movementPatterns;
    public List<Tile> moveableTiles;
    public List<Tile> attackableTiles;

    void Start()
    {
        Debug.Log($"Start - Unit: {displayName}");
        tile = gameObject.transform.parent.GetComponent<Tile>();
    }

    public void UpdateInfo() 
    {
        ChessBoardManager grid = FindObjectOfType<ChessBoardManager>();
        foreach (Vector2Int pattern in movementPatterns)
        {
            Tile otherTile = grid.SelectTile(pattern[0], pattern[1]).GetComponent<Tile>();
            if (otherTile.isOccupied) {attackableTiles.Add(otherTile);}
            else {moveableTiles.Add(otherTile);}
        }
    }
}
