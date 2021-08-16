using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Assignment_1.classes.Attributes;
using Assignment_1.classes.Equipment;


namespace Assignment_1.classes.Heroes
{
    public abstract class Hero
    {

        public Dictionary<int, Items> Equipment = new Dictionary<int, Items>();

        public Dictionary<int, Primary> EquippedStats = new Dictionary<int, Primary>();

        public string Name { get; set; }

        public int Level { get; set; }
        //Base stats should represent the hero's base stats, which means only the stats it gains from leveling up
        public Primary BaseAttributes { get; set; }
        //Total stats should be base stats + gear
        public Primary TotalPrimaryAttributes { get; set; }

        public Secondary SecondaryAttributes { get; set; }

        public int Damage { get; set; }

        public string Role { get; set; }

        public Hero(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public Primary LevelUp(Primary primary)
        {
            Primary NewPrimaryStats = new Primary
            {
                Strength = BaseAttributes.Strength + primary.Strength,
                Dexterity = BaseAttributes.Dexterity + primary.Dexterity,
                Intelligence = BaseAttributes.Intelligence + primary.Intelligence,
                Vitality = BaseAttributes.Vitality + primary.Vitality
            };

            return NewPrimaryStats;
        }

        //Currently this is only used for testing the character stats and siplaying it in the console
        public void Display()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Level : {Level}");
            Console.WriteLine($"Strenght : {TotalPrimaryAttributes.Strength}");
            Console.WriteLine($"Dexterity : {TotalPrimaryAttributes.Dexterity}");
            Console.WriteLine($"Intelligence : {TotalPrimaryAttributes.Intelligence}");
            Console.WriteLine($"Vitality : {TotalPrimaryAttributes.Vitality}");
            Console.WriteLine($"Health : {SecondaryAttributes.Health}");
            Console.WriteLine($"Armor rating : {SecondaryAttributes.ArmorRating}");
            Console.WriteLine($"Elemental Resistance : {SecondaryAttributes.ElementalResistance}");
            //DPS is wrong as for now
            Console.WriteLine($"DPS : {Damage}");
            Console.WriteLine("----------------------------------");
        }

        /// <summary>
        /// Updates the total primary attributes for a hero after equping a new armor piece
        /// </summary>
        /// <param name="TotalStats"></param>
        public Primary UpdateTotalPrimaryStats(Armor armor)
        {
            Primary TotalEquippedStats = new Primary();
            foreach(KeyValuePair<int, Primary> equippedStats in EquippedStats)
            {
                TotalEquippedStats.Strength += equippedStats.Value.Strength;
                TotalEquippedStats.Dexterity += equippedStats.Value.Dexterity;
                TotalEquippedStats.Intelligence += equippedStats.Value.Intelligence;
                TotalEquippedStats.Vitality += equippedStats.Value.Vitality;
            }
            Primary NewTotalStats = new Primary
            {
                Strength = BaseAttributes.Strength + TotalEquippedStats.Strength,
                Dexterity = BaseAttributes.Dexterity + TotalEquippedStats.Dexterity,
                Intelligence = BaseAttributes.Intelligence + TotalEquippedStats.Intelligence,
                Vitality = BaseAttributes.Vitality + TotalEquippedStats.Vitality
            };
            return NewTotalStats;
        }

        /// <summary>
        /// Updates the secondary stats of the hero
        /// </summary>
        /// <returns></returns>
        public Secondary UpdateSecondaryStats()
        {
            Secondary NewSecondaryStats = new Secondary
            {
                Health = TotalPrimaryAttributes.Vitality * 10,
                ArmorRating = TotalPrimaryAttributes.Strength + TotalPrimaryAttributes.Dexterity,
                ElementalResistance = TotalPrimaryAttributes.Intelligence
            };

            return NewSecondaryStats;
        }
    }
}
