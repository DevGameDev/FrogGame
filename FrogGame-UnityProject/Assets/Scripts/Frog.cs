using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitInterfaces;

public class FrogUnit : Unit, IDamageable, IDamageDealer
{
    // Unit
    static string displayName = "Frog";
    new bool isEnemy;

    // IDamageable //
    int maxHealth = 1;
    int _health;

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
    int currentAttack = startAttack;

    public void DealDamage(int damage, Unit otherUnit) // TODO: Implement
    {
        if (otherUnit is not IDamageable || isEnemy != otherUnit.isEnemy) {Debug.Log($"Unit: {name} failed attack on {otherUnit.name}; not damageable"); return;}
        IDamageable damageStats = (IDamageable)otherUnit.GetComponent(typeof(IDamageable));
        damageStats.ApplyDamage(damage);
    }

    void 
    // End //

    void Start()
    {
        _health = maxHealth;
        isEnemy = false;
    }

    void Update()
    {
        Debug.Log($"currentHealth = {_health}");
    }
}
