using System;
using Assignment_1.classes.Heroes;
using Assignment_1.classes.Equipment;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior hero = new Warrior("Martin");
            Weapon axe = new Weapon(2, Weapon.WeaponType.Axe);
            hero.EquipGear(axe);
        }
    }
}
