using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.classes.Equipment
{
    public class Weapon : Items
    {
        //BaseDamage is on a scale from 0-100 and Attack speed is on a scale from 0-5
        public int BaseDamage;
        public double AttackSpeed;
        //DPS, Damage Per Second, represents the base damage of a weapon * it's attack speed
        public double DPS;
        public WeaponType type;

        public enum WeaponType
        {
            Axe,
            Hammer,
            Bow,
            Dagger,
            Staff,
            Sword,
            Wand
        }
        public Weapon(int requiredLevel, WeaponType type)
        {
            Name = type.ToString();
            this.type = type;
            RequiredLevel = requiredLevel;
            Slot = Slots.Weapon;
            
            if(type == WeaponType.Wand || type == WeaponType.Dagger || type == WeaponType.Bow)
            {
                BaseDamage = 4 * requiredLevel;
                AttackSpeed = 1.3;
            } else if(type == WeaponType.Sword || type == WeaponType.Axe)
            {
                BaseDamage = 7 * requiredLevel;
                AttackSpeed = 1.1;
            } else
            {
                BaseDamage = 10 * requiredLevel;
                AttackSpeed = 0.8;
            }

            DPS = (BaseDamage * AttackSpeed);

        }
    }
}
