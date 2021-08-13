using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;

namespace Assignment_1.classes.Heroes
{
    class Rogue : Hero
    {
        /*
         *  Base stats = V 8, S 2, D 6, I 1
         * Level up = V 3, S 1, D 4, I 1
         * Secondary stats = H V * 10, AR S + D, ER I
         */

        public Rogue(string name, int level) : base(name, level)
        {
            this.Name = name;
            this.Level = level;
            var Primary = new Primary
            {
                Strength = 2 * level,
                Dexterity = 6 * level,
                Intelligence = 1 * level,
                Vitality = 8 * level
            };
            this.BasePrimaryAttributes = Primary;

            this.Damage += (this.BasePrimaryAttributes.Dexterity / 100);


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
            Console.WriteLine($"Your {this.Name} strength rose by {1}, dexterity rose by {4}, " +
                $"intelligence rose by {1} and vitality rose by {3}");
            this.BasePrimaryAttributes.Strength += 1;
            this.BasePrimaryAttributes.Dexterity += 4;
            this.BasePrimaryAttributes.Intelligence += 1;
            this.BasePrimaryAttributes.Vitality += 3;
            this.Level++;
        }

        public override void Display()
        {
            Console.WriteLine($"Name : {this.Name}, Level : {this.Level}, Dexterity : {this.BasePrimaryAttributes.Dexterity}");
        }
    }
}
