using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitLibrary
{
    abstract public class Unit : MonoBehaviour
    {
        // Basic Unit Information
        [HideInInspector] public string displayName;
        [HideInInspector] public bool isEnemy = false;
        [HideInInspector] public bool isSelectable = false;
        [HideInInspector] public bool isSelected = false;
        [HideInInspector] public bool isDamageable = false;
        [HideInInspector] public bool canMove = false;
        [HideInInspector] public bool canAttack = false;

        // Board Information
        [HideInInspector] public ChessBoardManager grid; // Grid Grandparent
        [HideInInspector] public Tile tile; // Tile Parent

        // Game Statistics
        protected int maxHealth;
        [HideInInspector] public int currentHealth;
        protected int attack;
        [HideInInspector] public List<Vector2Int> actionPatterns; // Array of Vector2Int -> (int xChange, int yChange) for each move

        protected List<Tile> moveableTiles; // List of tiles that could be moved to
        protected List<Tile> attackableTiles; // List of tiles that can be attacked

        protected virtual void Start()
        {
            Init();
        }

        protected virtual void Init() {
            gameObject.transform.tag = "unit";
            grid = FindObjectOfType<ChessBoardManager>();
            tile = gameObject.transform.parent.GetComponent<Tile>();
            currentHealth = maxHealth;
            UpdateInfo();
        }

        protected void UpdateInfo() 
        {
            ChessBoardManager grid2 = grid;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            // Check if any action patterns
            if (actionPatterns.Count == 0) return;

            // If so, cycle through them
            foreach (Vector2Int pattern in actionPatterns)
            {
                // Get tile
                Vector2Int position = tile.GetPosition();
                Tile otherTile = grid2.SelectTile(position.x + pattern[0], position.y + pattern[1]).GetComponent<Tile>();
                
                // If the tile is not occupied, can move here
                if (canMove && !otherTile.isOccupied) {moveableTiles.Add(otherTile); break;}

                // If the tile doesn't hold any objects, definitely no unit
                if (!(otherTile.tileContents.Count > 0)) {break;}

                Unit unit = null;
                // Look for a Unit (grabs first)
                foreach (GameObject obj in otherTile.tileContents)
                {
                    if (obj.CompareTag("unit")) {unit = obj.GetComponent<Unit>(); break;}
                }
                // If unit exists, is of opposite team, and can be damaged, can attack here
                if (canAttack && unit && isEnemy != unit.isEnemy && unit.isDamageable) attackableTiles.Add(otherTile);
            }
        }

        public bool AttemptAction(Tile otherTile) 
        {
            // Get Unit object in new tile
            Unit otherUnit = otherTile.transform.GetComponentInChildren<Unit>();
            
            // If the tile is empty and this unit can move, move
            if (!otherUnit && canMove) {Move(otherTile); UpdateInfo(); return true;}
            
            // If the other unit is not damageable or is on the same team, can't do anything
            if ((!otherUnit.isDamageable) || (isEnemy == otherUnit.isEnemy)) return false;
            
            // Attack enemy unit
            ApplyDamage(otherUnit);
            return true;
        }

        protected void Move(Tile otherTile)
        {
            // Set new tile as parent
            gameObject.transform.parent = otherTile.gameObject.transform;
        }

        protected void ApplyDamage(Unit otherUnit) 
        {
            otherUnit.currentHealth -= attack;
            if (otherUnit.currentHealth <= 0) otherUnit.die();
        }

        protected void die()
        {
            Destroy(gameObject);
        }
    }
}