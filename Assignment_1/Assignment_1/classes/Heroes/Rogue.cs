using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;
using Assignment_1.classes.Exceptions;

namespace Assignment_1.classes.Heroes
{
    class Rogue : Hero
    {
        public Rogue(string name, int level) : base(name, level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Rogue";

            var Primary = new Primary
            {
                Strength = 2 * level,
                Dexterity = 6 * level,
                Intelligence = 1 * level,
                Vitality = 8 * level
            };
            this.BaseAttributes = Primary;

            this.Damage += (this.BaseAttributes.Dexterity / 100);


            var Secondary = new Secondary
            {
                Health = this.BaseAttributes.Vitality * 10,
                ArmorRating = this.BaseAttributes.Strength + this.BaseAttributes.Dexterity,
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;

        }

        public override void LevelUp()
        {
            Console.WriteLine($"Your {this.Name} strength rose by {1}, dexterity rose by {4}, " +
                $"intelligence rose by {1} and vitality rose by {3}");

            //Primary attributes
            this.BaseAttributes.Strength += 1;
            this.BaseAttributes.Dexterity += 4;
            this.BaseAttributes.Intelligence += 1;
            this.BaseAttributes.Vitality += 3;

            //Secondary attributes
            this.SecondaryAttributes.Health = this.BaseAttributes.Vitality * 10;
            this.SecondaryAttributes.ArmorRating = this.BaseAttributes.Strength + this.BaseAttributes.Dexterity;
            this.SecondaryAttributes.ElementalResistance = this.BaseAttributes.Intelligence;
            

            this.Level++;
        }

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
