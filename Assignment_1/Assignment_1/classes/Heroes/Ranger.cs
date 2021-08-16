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
            this.Role = "Ranger";

            var Primary = new Primary
            {
                Strength = 1,
                Dexterity = 7,
                Intelligence = 1,
                Vitality = 8 
            };
            this.BaseAttributes = Primary;

            this.Damage = (this.BaseAttributes.Dexterity / 100);


            var Secondary = new Secondary
            {
                Health = this.BaseAttributes.Vitality * 10,
                ArmorRating = this.BaseAttributes.Strength + this.BaseAttributes.Dexterity,
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
        }
        public void LevelUp()
        {
            Primary LevelUpStats = new Primary
            {
                Strength = 1,
                Dexterity = 5,
                Intelligence = 1,
                Vitality = 2
            };
            this.BaseAttributes = this.LevelUp(LevelUpStats);
            this.SecondaryAttributes = this.UpdateSecondaryStats();
            this.Level++;
        }
    }
}
