using System;
using Assignment_1.classes.Heroes;
using Assignment_1.classes.Equipment;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Warrior war = new Warrior("Martin", 1);

            Weapon Axe = new Weapon(9, Weapon.WeaponType.Axe);
            Armor PlateHead = new Armor(1, Armor.ArmorType.Plate, Items.Slots.Head);

            //war.EquipGear(PlateHead);

            war.Display();
            war.EquipGear(PlateHead);
            war.Display();

            Console.WriteLine();
        }
    }
}
