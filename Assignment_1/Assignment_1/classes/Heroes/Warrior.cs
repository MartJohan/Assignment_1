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
        /// <param name="Strength"></param>
        /// <param name="Dexterity"></param>
        /// <param name="Intelligence"></param>
        /// <param name="Vitality"></param>
        /// <param name="hero"></param>
        public override void LevelUp(int Strength, int Dexterity, int Intelligence, int Vitality)
        {
            Console.WriteLine($"Your {this.Name} strength rose by {Strength}, dexterity rose by {Dexterity}, " +
                $"intelligence rose by {Intelligence} and vitality rose by {Vitality}");
            this.BasePrimaryAttributes.Strength += 3;
            this.BasePrimaryAttributes.Dexterity += 2;
            this.BasePrimaryAttributes.Intelligence += 1;
            this.BasePrimaryAttributes.Vitality += 10;
        }

        public void Display()
        {
            Console.Write($"Name : {this.Name}, Level : {this.Level}, Strength :{this.BasePrimaryAttributes.Strength}");
        }
    }
}
