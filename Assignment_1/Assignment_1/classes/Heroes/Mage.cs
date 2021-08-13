using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;

namespace Assignment_1.classes.Heroes
{
    class Mage : Hero
    {
        public Mage(string name, int level) : base(name, level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Mage";

            var Primary = new Primary
            {
                Strength = 5 * level,
                Dexterity = 1 * level,
                Intelligence = 8 * level,
                Vitality = 5 * level
            };
            this.BasePrimaryAttributes = Primary;

            this.Damage = (this.BasePrimaryAttributes.Intelligence / 100);


            var Secondary = new Secondary
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = (this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity),
                ElementalResistance = this.BasePrimaryAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
        }

        public override void LevelUp()
        {
            Console.WriteLine($"Your {this.Name} strength rose by {1}, dexterity rose by {1}, " +
                $"intelligence rose by {5} and vitality rose by {3}");
            this.BasePrimaryAttributes.Strength += 1;
            this.BasePrimaryAttributes.Dexterity += 1;
            this.BasePrimaryAttributes.Intelligence += 5;
            this.BasePrimaryAttributes.Vitality += 3;

            //Secondary attributes
            this.SecondaryAttributes.Health = this.BasePrimaryAttributes.Vitality * 10;
            this.SecondaryAttributes.ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity;
            this.SecondaryAttributes.ElementalResistance = this.BasePrimaryAttributes.Intelligence;
            this.Level++;
        }

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
