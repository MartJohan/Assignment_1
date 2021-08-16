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
            this.BaseAttributes = Primary;

            this.Damage = (this.BaseAttributes.Intelligence / 100);


            var Secondary = new Secondary
            {
                Health = this.BaseAttributes.Vitality * 10,
                ArmorRating = (this.BaseAttributes.Strength + this.BaseAttributes.Dexterity),
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
        }

        public override void LevelUp()
        {
            Console.WriteLine($"Your {this.Name} strength rose by {1}, dexterity rose by {1}, " +
                $"intelligence rose by {5} and vitality rose by {3}");
            this.BaseAttributes.Strength += 1;
            this.BaseAttributes.Dexterity += 1;
            this.BaseAttributes.Intelligence += 5;
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
