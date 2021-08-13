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

            //Create a new object of type Primary and initialize it's values
            //TODO Ask whether or not the base values should change depending on level, or if this is supposed to be the total primaryattributes
            var Primary = new Primary
            {
                Strength = 5 * level,
                Dexterity = 2 * level,
                Intelligence = 1 * level,
                Vitality = 10 * level
            };
            this.BasePrimaryAttributes = Primary;

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
        }

        //Currently this is only used for testing the character stats and siplaying it in the console
        public void Display()
        {
            Console.WriteLine($"Name : {this.Name}, Level : {this.Level}, Strength :{this.BasePrimaryAttributes.Strength}");
        }
    }
}
