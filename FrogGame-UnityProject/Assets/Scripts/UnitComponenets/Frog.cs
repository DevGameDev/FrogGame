using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitInterfaces;

public class FrogUnit : Unit, IDamageable, IDamageDealer
{
    // Unit
    static string displayName = "Frog";
    new bool isEnemy = false;
    int _health;
    int _attack;

    Tile tile;

    new public Vector2Int[] movementPatterns = 
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
    new public List<Tile> moveableTiles;
    new public List<Tile> attackableTiles;

    // IDamageable //
    int maxHealth = 1;

    public void ApplyDamage(int damage) 
    {
        _health -= damage;
        if (_health <= 0) die();
    }

    public void die()
    {
        // TODO Animation?
        Destroy(gameObject);
    }

    // IDamageDealer //
    static int startAttack = 1;

    public void DealDamage(int damage, Unit otherUnit) 
    {
        if (otherUnit is not IDamageable || isEnemy != otherUnit.isEnemy) {Debug.Log($"Unit: {name} failed attack on {otherUnit.name}; not damageable"); return;}
        IDamageable damageStats = (IDamageable)otherUnit.GetComponent(typeof(IDamageable));
        damageStats.ApplyDamage(damage);
    }

    // IMoveable
    void MoveUnit(Tile tile)
    {
        UpdateInfo();
        
    }

    // Misc
    void Start()
    {
        _health = maxHealth;
        _attack = startAttack;
        UpdateInfo();
    }
}
