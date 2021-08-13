using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;

namespace Assignment_1.classes.Heroes
{
    class Ranger : Hero
    {
        public Ranger(string name, int level) : base(name,level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Ranger";

            var Primary = new Primary
            {
                Strength = 1,
                Dexterity = 7,
                Intelligence = 1,
                Vitality = 8 
            };
            this.BasePrimaryAttributes = Primary;

            this.Damage = (this.BasePrimaryAttributes.Dexterity / 100);


            var Secondary = new Secondary
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
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

        public override void LevelUp()
        {
            Console.WriteLine($"Your {this.Name} strength rose by {1}, dexterity rose by {5}, " +
               $"intelligence rose by {1} and vitality rose by {2}");
            this.BasePrimaryAttributes.Strength += 1;
            this.BasePrimaryAttributes.Dexterity += 5;
            this.BasePrimaryAttributes.Intelligence += 1;
            this.BasePrimaryAttributes.Vitality += 2;

            //Secondary attributes
            this.SecondaryAttributes.Health = this.BasePrimaryAttributes.Vitality * 10;
            this.SecondaryAttributes.ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity;
            this.SecondaryAttributes.ElementalResistance = this.BasePrimaryAttributes.Intelligence;
            this.Level++;
        }
    }
}
