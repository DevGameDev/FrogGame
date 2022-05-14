using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBasic : Unit, IDamageable, IDamageDealer
{
    // Basic Unit Definitions
    static string displayName = "Frog";
    bool isEnemy = false;

    // IDamageable //
    int maxHealth = 1;
    int currentHealth;

    public void ApplyDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth <= 0) kill();
    }

    public void kill() {Destroy(gameObject);}
    // End //

    // IDamageDealer //
    static int startAttack = 1;
    int currentAttack = startAttack;

    public void DealDamage(int damage, Unit otherUnit) // TODO: Implement
    {
        if (otherUnit is not IDamageable) Debug.Log($"Unit: {name} failed attack on {otherUnit.name}; not damageable");
    }
    // End //

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Debug.Log($"currentHealth = {currentHealth}");
    }
}
