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

        public double Damage { get; set; }

        public string Role { get; set; }

        public Hero(string name)
        {
            Name = name;
        }

        /// <summary>
        /// This method takes in an object with some primary stats and updates the characters primary stats
        /// </summary>
        /// <param name="primary"></param>
        /// <returns></returns>
        public abstract void LevelUp();

        /// <summary>
        /// Displays the name, level, total primary stats, total secondary stats and damage of the hero
        /// </summary>
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
            Console.WriteLine($"DPS : {Damage}");
            Console.WriteLine("----------------------------------");
        }

        /// <summary>
        /// Updates the total primary attributes for a hero after equping a new armor piece
        /// </summary>
        /// <param name="TotalStats"></param>
        public Primary UpdateTotalPrimaryStats()
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

        /// <summary>
        /// Calculates the dps for a charatcer with the appropriate primary stats in mind
        /// </summary>
        /// <returns></returns>
        public double CalculateDPS()
        {
            Items value;
            if(!Equipment.TryGetValue(4, out value))
            {
                return 0;
            }
            Weapon weapon = (Weapon)value;
            switch (Role)
            {
                case ("Warrior"):
                    Damage = weapon.DPS * (1 + TotalPrimaryAttributes.Strength / 100);
                    break;

                case ("Rogue"):
                    Damage = weapon.DPS * (1 + TotalPrimaryAttributes.Dexterity / 100);
                    break;

                case ("Ranger"):
                    Damage = weapon.DPS * (1 + TotalPrimaryAttributes.Dexterity / 100);
                    break;

                case ("Mage"):
                    Damage = weapon.DPS * (1 + TotalPrimaryAttributes.Intelligence / 100);
                    break;
            }
            return Damage;
        }

    }
}
