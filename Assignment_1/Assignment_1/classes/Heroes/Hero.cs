using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assignment_1.classes.Attributes;


namespace Assignment_1.classes.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; }

        private int Level { get; set; }

        public Primary BasePrimaryAttributes { get; set; }

        public Primary TotalPrimaryAttributes { get; set; }

        public Secondary SecondaryAttributes { get; set; }

        public Hero(string name, int level, Primary basePrimaryAttributes,
            Primary totalPrimaryAttribute, Secondary secondaryAttributes)
        {
            Name = name;
            Level = level;
            BasePrimaryAttributes = basePrimaryAttributes;
            TotalPrimaryAttributes = totalPrimaryAttribute;
            SecondaryAttributes = secondaryAttributes;
        }

        public virtual void LevelUp(int Strength, int Dexterity, int Intelligence, int Vitality, Hero hero)
        {

            Console.WriteLine($"Congratulations! {hero.Name}'s strength rose by {Strength}, dexterity rose by {Dexterity}, " +
                $"intelligence rose by {Intelligence} and vitality rose by {Vitality}");
        }


    }
}
