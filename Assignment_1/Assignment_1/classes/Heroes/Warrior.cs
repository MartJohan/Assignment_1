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

        public Warrior(string Name, int Level,
            Primary BasePrimaryAttributes,
            Primary TotalPrimaryAttributes,Secondary SecondaryAttributes)
            : base(Name, Level, BasePrimaryAttributes, TotalPrimaryAttributes, SecondaryAttributes)
        {
            BasePrimaryAttributes.Strength = 5;
            BasePrimaryAttributes.Dexterity = 2;
            BasePrimaryAttributes.Intelligence = 1;
            BasePrimaryAttributes.Vitality = 10;
        }

        /// <summary>
        /// Takes in all the base values and updates them accordingly each time the hero levels up.
        /// </summary>
        /// <param name="Strength"></param>
        /// <param name="Dexterity"></param>
        /// <param name="Intelligence"></param>
        /// <param name="Vitality"></param>
        /// <param name="hero"></param>
        public override void LevelUp(int Strength, int Dexterity, int Intelligence, int Vitality, Hero hero)
        {
            Console.WriteLine($"Your characters strength rose by {Strength}, dexterity rose by {Dexterity}, " +
                $"intelligence rose by {Intelligence} and vitality rose by {Vitality}");
            hero.BasePrimaryAttributes.Strength += 3;
            hero.BasePrimaryAttributes.Dexterity += 2;
            hero.BasePrimaryAttributes.Intelligence += 1;
            hero.BasePrimaryAttributes.Vitality += 10;
        }

    }
}
