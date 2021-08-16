using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;
using Assignment_1.classes.Exceptions;

namespace Assignment_1.classes.Heroes
{
    class Rogue : Hero
    {
        public Rogue(string name, int level) : base(name, level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Rogue";

            var Primary = new Primary
            {
                Strength = 2 * level,
                Dexterity = 6 * level,
                Intelligence = 1 * level,
                Vitality = 8 * level
            };
            this.BaseAttributes = Primary;

            this.Damage += (this.BaseAttributes.Dexterity / 100);


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
                Dexterity = 4,
                Intelligence = 1,
                Vitality = 3
            };
            this.BaseAttributes = this.LevelUp(LevelUpStats);
            this.SecondaryAttributes = this.UpdateSecondaryStats();
            this.Level++;
        }
    }
}
