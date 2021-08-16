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
    public class Warrior : Hero
    {
        Dictionary<int, Items> Equipment = new Dictionary<int, Items>();
        public Warrior(string name, int level) : base(name,level)
        {
            this.Name = name;
            this.Level = level;
            this.Role = "Warrior";

            //Create a new object of type Primary and initialize it's values
            var Primary = new Primary
            {
                Strength = 5 * level,
                Dexterity = 2 * level,
                Intelligence = 1 * level,
                Vitality = 10 * level
            };
            this.BaseAttributes = Primary;
            this.TotalPrimaryAttributes = this.BaseAttributes;
            this.Damage = (this.BaseAttributes.Strength / 100);


            //Same thing with the secondary values
            var Secondary = new Secondary
            {
                Health = (this.BaseAttributes.Vitality * 10),
                ArmorRating = (this.BaseAttributes.Strength + this.BaseAttributes.Dexterity),
                ElementalResistance = this.BaseAttributes.Intelligence
            };
            this.SecondaryAttributes = Secondary;
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
        /// </summary>
        /// <param name="armor"></param>
        public void EquipGear(Armor armor)
        {
            try
            {
                if(armor.armorType != Armor.ArmorType.Mail && armor.armorType != Armor.ArmorType.Plate)
                {
                    throw new InvalidArmorException($"As a {this.Role} you cannot use {armor.armorType}");
                } else if(armor.RequiredLevel > this.Level)
                {
                    throw new InvalidArmorException("This armor is to high leveled for you to use");
                }

                //Here we remove the key before we add a new one to prevent an ArgumentException being thrown.
                    switch (armor.Slot)
                    {
                        case (Items.Slots.Head):
                            this.Equipment.Remove(1);
                            this.Equipment.Add(1, armor);
                            break;

                        case (Items.Slots.Body):
                            this.Equipment.Remove(2);
                            this.Equipment.Add(2, armor);
                            break;

                        case (Items.Slots.Legs):
                            this.Equipment.Remove(3);
                            this.Equipment.Add(3, armor);
                            break;
                    }

                this.TotalPrimaryAttributes = this.UpdateTotalPrimaryStats(armor);
                this.SecondaryAttributes = this.UpdateSecondaryStats();
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
                Console.WriteLine($"Your level {this.Level}, weapon level {weapon.RequiredLevel}");
                if (weapon.type != Weapon.WeaponType.Axe && weapon.type != Weapon.WeaponType.Hammer && weapon.type != Weapon.WeaponType.Sword)
                {
                    throw new InvalidWeaponException($"As a {this.Role} you cannot use this type of weapon");
                } else if(weapon.RequiredLevel > this.Level)
                {
                    throw new InvalidWeaponException($"This weapon requires you to be level {weapon.RequiredLevel}");
                }

                this.Equipment.Remove(4);
                this.Equipment.Add(4, weapon);
            } catch(InvalidWeaponException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
    }
}
