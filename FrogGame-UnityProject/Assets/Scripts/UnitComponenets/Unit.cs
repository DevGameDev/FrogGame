using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Basic Unit Info
    string displayName;
    public bool isEnemy = false;

    // Game Stats
    int _health; // Always defined, but no interaction for non-damageable units
    int _attack; // Always defined, but no interaction for non-agressive units

    ChessBoardManager grid; // Grid Grandparent
    Tile tile; // Tile Parent

    public Vector2Int[] movementPatterns; // Array of Vector2Int -> (int xChange, int yChange) for each move
    public List<Tile> moveableTiles; // List of tiles that could be moved to
    public List<Tile> attackableTiles; // List of tiles that can be attacked

    void Start()
    {
        gameObject.transform.tag = "Unit";
        ChessBoardManager grid = FindObjectOfType<ChessBoardManager>();
        tile = gameObject.transform.parent.GetComponent<Tile>();
        Debug.Log($"Unit: {displayName} Started");
    }

    public void UpdateInfo() 
    {
        // Cycle through each movement patter
        foreach (Vector2Int pattern in movementPatterns)
        {
            // Get tile
            Tile otherTile = grid.SelectTile(pattern[0], pattern[1]).GetComponent<Tile>();
            
            // If the tile is not occupied, can move there
            if (!otherTile.isOccupied) {moveableTiles.Add(otherTile); break;}

            // If the tile holds any game objects
            if (otherTile.tileContents.Count > 0)
            {
                Unit unit = null;
                // Look for a Unit
                foreach (GameObject obj in otherTile.tileContents)
                {
                    if (obj.CompareTag("Unit")) unit = obj.GetComponent<Unit>();
                }
                // If the unit is opposite team, can attack there
                if (unit is not null && isEnemy != unit.isEnemy) attackableTiles.Add(otherTile);
            }
        }
    }
}
