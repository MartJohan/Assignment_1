using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Exceptions;

namespace Assignment_1.classes.Heroes
{
    public class Ranger : Hero
    {
        /// <summary>
        /// The constructor, initialize the hero with a name, level and role.
        /// The hero is assigned primary and secondary stats based on it's role
        /// </summary>
        /// <param name="name"></param>
        public Ranger(string name) : base(name)
        {
            this.Name = name;
            this.Level = 1;
            this.Role = "Ranger";

            var Primary = new Primary
            {
                Strength = 1 * Level,
                Dexterity = 7 * Level,
                Intelligence = 1 * Level,
                Vitality = 8 * Level
            };
            BaseAttributes = Primary;
            TotalPrimaryAttributes = BaseAttributes;

            var Secondary = new Secondary
            {
                Health = this.BaseAttributes.Vitality * 10,
                ArmorRating = this.BaseAttributes.Strength + this.BaseAttributes.Dexterity,
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            SecondaryAttributes = Secondary;
        }

        /// <summary>
        /// Levels up the hero and updates the stats
        /// </summary>
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

        /// <summary>
        /// A method for the hero to equip it's gear, this only applies to armor
        /// First it is implemented a check to make sure that the type of armor is acceptable
        /// Secondly, it is check that the armor meeets the level requirement
        /// Thirdly, the armor is put in it's appropriate slot
        /// Last, but not least, the primary attribute of the armor are added to the total primary attribute of the hero
        ///The parameter armor is the armor piece we are trying to equip
        ////// The function returns a string which indicates that the armor could have been equipped
        /// </summary>
        /// <param name="armor"></param>
        public string EquipGear(Armor armor)
        {
                if (armor.armorType != Armor.ArmorType.Mail && armor.armorType != Armor.ArmorType.Leather)
                {
                    throw new InvalidArmorException($"As a {Role} you cannot use {armor.armorType}");
                }
                else if (armor.RequiredLevel > Level)
                {
                    throw new InvalidArmorException("This armor is to high leveled for you to use");
                }

                //Here we remove the key before we add a new one to prevent an ArgumentException being thrown.
                switch (armor.Slot)
                {
                    case (Items.Slots.Head):
                        Equipment.Remove(1);
                        EquippedStats.Remove(1);

                        Equipment.Add(1, armor);
                        EquippedStats.Add(1, armor.BaseAttributes);
                        break;

                    case (Items.Slots.Body):
                        Equipment.Remove(2);
                        EquippedStats.Remove(2);

                        Equipment.Add(2, armor);
                        EquippedStats.Add(2, armor.BaseAttributes);
                        break;

                    case (Items.Slots.Legs):
                        Equipment.Remove(3);
                        EquippedStats.Remove(3);

                        Equipment.Add(3, armor);
                        EquippedStats.Add(3, armor.BaseAttributes);
                        break;
                }

                TotalPrimaryAttributes = UpdateTotalPrimaryStats();
                SecondaryAttributes = UpdateSecondaryStats();
                Damage = CalculateDPS();
            return "New armor equipped";
        }

        /// <summary>
        /// First it is check what type of weapon it is and verified whether or not it can be equipped
        /// Second, it is checked whether or not the required level for the weapon is too high
        /// Thirdly, the weapon is eqipped
        /// Last, but not least, the stats are added
        /// The parameter weapon is the weapon we are trying to equip
        /// </summary>
        /// <param name="weapon"></param>
        public string EquipGear(Weapon weapon)
        {
            CheckGear(weapon);
            Equipment.Remove(4);
            Equipment.Add(4, weapon);
            Damage = CalculateDPS();
            return "New weapon equipped";
        }

        public bool CheckGear(Weapon weapon)
        {
            if (weapon.type != Weapon.WeaponType.Bow)
            {
                throw new InvalidWeaponException($"As a {Role} you cannot use this type of weapon");
            }
            else if (weapon.RequiredLevel > Level)
            {
                throw new InvalidWeaponException($"This weapon requires you to be level {weapon.RequiredLevel}");
            }

            return true;
        }
    }
}
