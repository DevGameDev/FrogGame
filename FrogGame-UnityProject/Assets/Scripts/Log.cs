using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitLibrary;

public class Log : Unit
{
    protected override void Start()
    {
        // Set permissions
        displayName = "Log";
        isDamageable = true;
        
        // Set Stats
        currentHealth = maxHealth = 1;
        base.Start();
    }
}
