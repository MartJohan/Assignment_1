using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;

namespace Assignment_1.classes.Heroes
{
    public class Warrior : Hero
    {


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
            this.BasePrimaryAttributes = Primary;


            this.Damage = (this.BasePrimaryAttributes.Strength / 100);


            //Same thing with the secondary values
            var Secondary = new Secondary
            {
                Health = (this.BasePrimaryAttributes.Vitality * 10),
                ArmorRating = (this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity),
                ElementalResistance = this.BasePrimaryAttributes.Intelligence
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
            this.BasePrimaryAttributes.Strength += 3;
            this.BasePrimaryAttributes.Dexterity += 2;
            this.BasePrimaryAttributes.Intelligence += 1;
            this.BasePrimaryAttributes.Vitality += 10;

            //Secondary attributes
            this.SecondaryAttributes.Health = this.BasePrimaryAttributes.Vitality * 10;
            this.SecondaryAttributes.ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity;
            this.SecondaryAttributes.ElementalResistance = this.BasePrimaryAttributes.Intelligence;
            this.Level++;
        }

        //Currently this is only used for testing the character stats and siplaying it in the console
        public override void Display()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Level : {this.Level}");
            Console.WriteLine($"Strenght : {this.BasePrimaryAttributes.Strength}");
            Console.WriteLine($"Dexterity : {this.BasePrimaryAttributes.Dexterity}");
            Console.WriteLine($"Intelligence : {this.BasePrimaryAttributes.Intelligence}");
            Console.WriteLine($"Vitality : {this.BasePrimaryAttributes.Vitality}");
            Console.WriteLine($"Health : {this.SecondaryAttributes.Health}");
            Console.WriteLine($"Armor rating : {this.SecondaryAttributes.ArmorRating}");
            Console.WriteLine($"Elemental Resistance : {this.SecondaryAttributes.ElementalResistance}");
            //DPS is wrong as for now
            Console.WriteLine($"DPS : {this.Damage}");
        }
    }
}
