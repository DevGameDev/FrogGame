using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBasic : Unit, IDamageable, IDamageDealer
{
    static int startHealth = 1;
    static int startAttack = 1;

    int _health = startHealth;
    int _attack = startAttack;

    int currentHealth {
        get => _health;
        set => _health = value;
    }

    void ApplyDamage(int damage) 
    {
        currentHealth = 2;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log($"currentHealth = {currentHealth}");
        Debug.Log($"_health = {_health}");
    }
}
