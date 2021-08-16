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

        public abstract void LevelUp();

        public abstract void Display();


    }
}
