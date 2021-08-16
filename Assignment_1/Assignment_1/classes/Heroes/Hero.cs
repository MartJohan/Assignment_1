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
        public string Name { get; set; }

        public int Level { get; set; }
        //Base stats should represent the hero's base stats, which means only the stats it gains from leveling up
        public Primary BaseAttributes { get; set; }
        //Total stats should be base stats + gear
        public Primary TotalPrimaryAttributes { get; set; }

        public Secondary SecondaryAttributes { get; set; }

        public int Damage { get; set; }

        public string Role { get; set; }

        Dictionary<Items.Slots, Armor.ArmorType> Equipment = new Dictionary<Items.Slots, Armor.ArmorType>();

        public Hero(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public Primary LevelUp(Primary primary)
        {
            Console.WriteLine($"Your hero leveled up, your strength rose by {primary.Strength}," +
                $" dexterity rose by {primary.Dexterity}, intelligence rose by {primary.Intelligence}" +
                $" and vitality rose by {primary.Vitality}, you rock!");

            Primary NewPrimaryStats = new Primary
            {
                Strength = this.BaseAttributes.Strength + primary.Strength,
                Dexterity = this.BaseAttributes.Dexterity + primary.Dexterity,
                Intelligence = this.BaseAttributes.Intelligence + primary.Intelligence,
                Vitality = this.BaseAttributes.Vitality + primary.Vitality
            };

            return NewPrimaryStats;
        }

        // public abstract void EquipGear(Type type);

        //Currently this is only used for testing the character stats and siplaying it in the console
        public void Display()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Level : {this.Level}");
            Console.WriteLine($"Strenght : {this.TotalPrimaryAttributes.Strength}");
            Console.WriteLine($"Dexterity : {this.TotalPrimaryAttributes.Dexterity}");
            Console.WriteLine($"Intelligence : {this.TotalPrimaryAttributes.Intelligence}");
            Console.WriteLine($"Vitality : {this.TotalPrimaryAttributes.Vitality}");
            Console.WriteLine($"Health : {this.SecondaryAttributes.Health}");
            Console.WriteLine($"Armor rating : {this.SecondaryAttributes.ArmorRating}");
            Console.WriteLine($"Elemental Resistance : {this.SecondaryAttributes.ElementalResistance}");
            //DPS is wrong as for now
            Console.WriteLine($"DPS : {this.Damage}");
            Console.WriteLine("----------------------------------");
        }

        /// <summary>
        /// Updates the total primary attributes for a hero after equping a new armor piece
        /// </summary>
        /// <param name="TotalStats"></param>
        public Primary UpdateTotalPrimaryStats(Armor armor)
        {
            Primary NewTotalStats = new Primary
            {
                Strength = this.TotalPrimaryAttributes.Strength + armor.BaseAttributes.Strength,
                Dexterity = this.TotalPrimaryAttributes.Dexterity + armor.BaseAttributes.Dexterity,
                Intelligence = this.TotalPrimaryAttributes.Intelligence + armor.BaseAttributes.Intelligence,
                Vitality = this.TotalPrimaryAttributes.Vitality + armor.BaseAttributes.Vitality
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
                Health = this.TotalPrimaryAttributes.Vitality * 10,
                ArmorRating =this.TotalPrimaryAttributes.Strength + this.TotalPrimaryAttributes.Dexterity,
                ElementalResistance = this.TotalPrimaryAttributes.Intelligence
            };

            return NewSecondaryStats;
        }


    }
}
