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
            this.Name = type.ToString();
            this.type = type;
            this.RequiredLevel = requiredLevel;
            this.Slot = Slots.Weapon;
            
            if(type == WeaponType.Wand || type == WeaponType.Dagger || type == WeaponType.Bow)
            {
                this.BaseDamage = 40;
                this.AttackSpeed = 4;
            } else if(type == WeaponType.Sword || type == WeaponType.Axe)
            {
                this.BaseDamage = 60;
                this.AttackSpeed = 2.5;
            } else
            {
                this.BaseDamage = 85;
                this.AttackSpeed = 1.89;
            }

            this.DPS = (this.BaseDamage * this.AttackSpeed);

        }
    }
}
