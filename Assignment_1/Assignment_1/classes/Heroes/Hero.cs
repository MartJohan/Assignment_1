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

        public int Level { get; set; }

        public Primary BasePrimaryAttributes { get; set; }

        public Primary TotalPrimaryAttributes { get; set; }

        public Secondary SecondaryAttributes { get; set; }

        public Hero(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public virtual void LevelUp()
        {

            Console.WriteLine($"Congratulations! {this.Name}'s strength rose by {0}, dexterity rose by {0}, " +
                $"intelligence rose by {0} and vitality rose by {0}");
        }


    }
}
