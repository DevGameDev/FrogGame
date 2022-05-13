using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    static int maxHealth;
    static int currentHealth; // Set to maxHealth in Start()
    void ApplyDamage(int damage);
    void kill();
}

public interface IDamageDealer
{
    static int startAttack;
    static int currentAttack;
    void DealDamage(int damage, Unit unit);
}

public interface IHealer // TODO Remove or find use
{
    int startHealing { get; set; }
    int currentHealing { get; set; }
    void Heal(int healing);
}

abstract public class Unit : MonoBehaviour
{
    // Basic Unit Info
    string displayName;
    bool isEnemy = false;

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
        return;
    }
}
