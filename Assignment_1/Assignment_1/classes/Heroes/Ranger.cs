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
            //Base stats : V 8, S 1, D 7, I 1
            //Level up : V 2, S 1, D 5, I 1
            //Secondary stats = H V * 10, AR S +D, ER I
            var Primary = new Primary
            {
                Strength = 1,
                Dexterity = 7,
                Intelligence = 1,
                Vitality = 8 
            };
            this.BasePrimaryAttributes = Primary;

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
            Console.WriteLine($"Name : {this.Name}, Level : {this.Level}, Dexterity :{this.BasePrimaryAttributes.Dexterity}");
        }

        public override void LevelUp()
        {
            Console.WriteLine($"Your {this.Name} strength rose by {1}, dexterity rose by {5}, " +
               $"intelligence rose by {1} and vitality rose by {2}");
            this.BasePrimaryAttributes.Strength += 1;
            this.BasePrimaryAttributes.Dexterity += 5;
            this.BasePrimaryAttributes.Intelligence += 1;
            this.BasePrimaryAttributes.Vitality += 2;
        }
    }
}
