﻿using System;
using Assignment_1.classes.Heroes;
using Assignment_1.classes.Equipment;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {

            

            Rogue war = new Rogue("Martin", 1);
            war.Display();
            war.LevelUp();
            war.Display();

            Weapon Axe = new Weapon(9, Weapon.WeaponType.Axe);
            Armor Chest = new Armor(11, Armor.ArmorType.Plate, Items.Slots.Body);

            Console.WriteLine(Axe.DPS);
        }
    }
}
