using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitInterfaces
{
    public interface IDamageable
    {
        static int maxHealth;
        void ApplyDamage(int damage);
        void die();
    }

    public interface IDamageDealer
    {
        static int startAttack;
        void DealDamage(int damage, Unit unit);
        // List<Tile2D> GetAttackInfo();
    }

    public interface IHealer
    {
        int startHealing { get; set; }
        int currentHealing { get; set; }
        void Heal(int healing);
    }

    public interface IMoveable
    {
        int moveRange { get; set; }
        // List<Tile2D> GetMoveInfo();
    }
}
