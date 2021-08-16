using System;
using Assignment_1.classes.Heroes;
using Assignment_1.classes.Equipment;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Warrior war = new Warrior("Martin", 5);

            Weapon Axe = new Weapon(3, Weapon.WeaponType.Axe);
            Armor PlateHead = new Armor(5, Armor.ArmorType.Plate, Items.Slots.Head);
            Armor PlateBody = new Armor(5, Armor.ArmorType.Plate, Items.Slots.Body);
            Armor MailLegs = new Armor(5, Armor.ArmorType.Mail, Items.Slots.Legs);

            war.Display();
            
            war.EquipGear(PlateHead);
            war.EquipGear(PlateBody);
            war.EquipGear(MailLegs);
            war.EquipGear(Axe);

            war.Display();
        }
    }
}
