using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    static int startHealth;
    int currentHealth { get; set; }
    void ApplyDamage(int damage);
}

public interface IDamageDealer
{
    static int startAttack;
    int currentAttack { get; set; }
    void DealDamage(int damage);
}

public interface IHealer
{
    int startHealing { get; set; };
    int currentHealing { get; set; }
    void Heal(int healing);
}

public class Unit : MonoBehaviour
{
    // Basic Unit Info
    string name;

    void Start()
    {
        Debug.Log($"Start - Unit: {name}")
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
