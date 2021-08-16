﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Exceptions;

namespace Assignment_1.classes.Heroes
{
    public class Warrior : Hero
    {
        
        public Warrior(string name, int level) : base(name,level)
        {
            Name = name;
            Level = level;
            Role = "Warrior";

            //Create a new object of type Primary and initialize it's values
            var Primary = new Primary
            {
                Strength = 5 * level,
                Dexterity = 2 * level,
                Intelligence = 1 * level,
                Vitality = 10 * level
            };
            BaseAttributes = Primary;
            TotalPrimaryAttributes = this.BaseAttributes;
            Damage = (BaseAttributes.Strength / 100);
            Console.WriteLine(Damage);


            //Same thing with the secondary values
            var Secondary = new Secondary
            {
                Health = (BaseAttributes.Vitality * 10),
                ArmorRating = (BaseAttributes.Strength + BaseAttributes.Dexterity),
                ElementalResistance = BaseAttributes.Intelligence
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
                Strength = 3,
                Dexterity = 2,
                Intelligence = 1,
                Vitality = 10
            };
            BaseAttributes = LevelUp(LevelUpStats);
            SecondaryAttributes = UpdateSecondaryStats();
            Level++;
        }

        /// <summary>
        /// A method for the hero to equip it's gear, this only applies to armor
        /// First it is implemented a check to make sure that the type of armor is acceptable
        /// Secondly, it is check that the armor meeets the level requirement
        /// Thirdly, the armor is put in it's appropriate slot
        /// Last, but not least, the primary attribute of the armor are added to the total primary attribute of the hero
        /// </summary>
        /// <param name="armor"></param>
        public void EquipGear(Armor armor)
        {
            try
            {
                if(armor.armorType != Armor.ArmorType.Mail && armor.armorType != Armor.ArmorType.Plate)
                {
                    throw new InvalidArmorException($"As a {Role} you cannot use {armor.armorType}");
                } else if(armor.RequiredLevel > Level)
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

                TotalPrimaryAttributes = UpdateTotalPrimaryStats(armor);
                SecondaryAttributes = UpdateSecondaryStats();
            } catch(InvalidArmorException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// First it is check what type of weapon it is and verified whether or not it can be equipped
        /// Second, it is checked whether or not the required level for the weapon is too high
        /// Thirdly, the weapon is eqipped
        /// Last, but not least, the stats are added
        /// </summary>
        /// <param name="weapon"></param>
        public void EquipGear(Weapon weapon)
        {
            try
            {
                Console.WriteLine($"Your level {Level}, weapon level {weapon.RequiredLevel}");
                if (weapon.type != Weapon.WeaponType.Axe && weapon.type != Weapon.WeaponType.Hammer && weapon.type != Weapon.WeaponType.Sword)
                {
                    throw new InvalidWeaponException($"As a {Role} you cannot use this type of weapon");
                } else if(weapon.RequiredLevel > Level)
                {
                    throw new InvalidWeaponException($"This weapon requires you to be level {weapon.RequiredLevel}");
                }

                Equipment.Remove(4);
                Equipment.Add(4, weapon);
            } catch(InvalidWeaponException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
    }
}
