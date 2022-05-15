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
    }

    public interface IMoveable
    {
        static Vector2Int[] movementPatterns;
        void MoveUnit(Tile newTile);
    }
}
