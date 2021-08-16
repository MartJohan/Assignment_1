using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;

namespace Assignment_1.classes.Heroes
{
    class Mage : Hero
    {
        public Mage(string name, int level) : base(name, level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Mage";

            var Primary = new Primary
            {
                Strength = 5 * level,
                Dexterity = 1 * level,
                Intelligence = 8 * level,
                Vitality = 5 * level
            };
            this.BaseAttributes = Primary;

            this.Damage = (this.BaseAttributes.Intelligence / 100);


            var Secondary = new Secondary
            {
                Health = this.BaseAttributes.Vitality * 10,
                ArmorRating = (this.BaseAttributes.Strength + this.BaseAttributes.Dexterity),
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
        }

        public void LevelUp()
        {
            Primary LevelUpStats = new Primary
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 5,
                Vitality = 3
            };
            this.BaseAttributes = this.LevelUp(LevelUpStats);
            this.SecondaryAttributes = this.UpdateSecondaryStats();
            this.Level++;
        }
    }
}
