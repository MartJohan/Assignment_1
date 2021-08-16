using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Exceptions;

namespace Assignment_1.classes.Heroes
{
    public class Warrior : Hero
    {
        Dictionary<int, Armor> Equipment = new Dictionary<int, Armor>();
        public Warrior(string name, int level) : base(name,level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Warrior";

            //Create a new object of type Primary and initialize it's values
            var Primary = new Primary
            {
                Strength = 5 * level,
                Dexterity = 2 * level,
                Intelligence = 1 * level,
                Vitality = 10 * level
            };
            this.BaseAttributes = Primary;
            this.Damage = (this.BaseAttributes.Strength / 100);


            //Same thing with the secondary values
            var Secondary = new Secondary
            {
                Health = (this.BaseAttributes.Vitality * 10),
                ArmorRating = (this.BaseAttributes.Strength + this.BaseAttributes.Dexterity),
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
            }

        /// <summary>
        /// Takes in all the base values and updates them accordingly each time the hero levels up.
        /// </summary>
        public override void LevelUp()
        {
            Console.WriteLine($"Your {this.Name} strength rose by {3}, dexterity rose by {2}, " +
                $"intelligence rose by {1} and vitality rose by {10}");
            this.BaseAttributes.Strength += 3;
            this.BaseAttributes.Dexterity += 2;
            this.BaseAttributes.Intelligence += 1;
            this.BaseAttributes.Vitality += 10;

            //Secondary attributes
            this.SecondaryAttributes.Health = this.BaseAttributes.Vitality * 10;
            this.SecondaryAttributes.ArmorRating = this.BaseAttributes.Strength + this.BaseAttributes.Dexterity;
            this.SecondaryAttributes.ElementalResistance = this.BaseAttributes.Intelligence;
            this.Level++;
        }

        public void EquipGear(Armor armor)
        {
            /*
             * Check if the armor is going to be placed in the correct slot
             */

            try
            {
                if(armor.armorType != Armor.ArmorType.Mail && armor.armorType != Armor.ArmorType.Plate)
                {
                    throw new InvalidArmorException($"As a {this.Role} you cannot use {armor.armorType}");
                } else if(armor.RequiredLevel > this.Level)
                {
                    throw new InvalidArmorException("This armor is to high leveled for you to use");
                }





            } catch(InvalidArmorException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //Currently this is only used for testing the character stats and siplaying it in the console
        public override void Display()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Level : {this.Level}");
            Console.WriteLine($"Strenght : {this.BaseAttributes.Strength}");
            Console.WriteLine($"Dexterity : {this.BaseAttributes.Dexterity}");
            Console.WriteLine($"Intelligence : {this.BaseAttributes.Intelligence}");
            Console.WriteLine($"Vitality : {this.BaseAttributes.Vitality}");
            Console.WriteLine($"Health : {this.SecondaryAttributes.Health}");
            Console.WriteLine($"Armor rating : {this.SecondaryAttributes.ArmorRating}");
            Console.WriteLine($"Elemental Resistance : {this.SecondaryAttributes.ElementalResistance}");
            //DPS is wrong as for now
            Console.WriteLine($"DPS : {this.Damage}");
        }
    }
}
