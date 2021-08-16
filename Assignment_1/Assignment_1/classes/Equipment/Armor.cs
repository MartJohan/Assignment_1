﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Attributes;

namespace Assignment_1.classes.Equipment
{
    public class Armor : Items
    {
        public Primary BaseAttributes;
        public ArmorType armorType;
        public enum ArmorType
        {
            Cloth,
            Leather,
            Mail,
            Plate
        }
        public Armor(int requiredLevel, ArmorType armor, Slots slot)
        {
            this.Name = armor.ToString();
            this.RequiredLevel = requiredLevel;
            this.Slot = slot;
            this.armorType = armor;


            Primary Primary = new Primary();
            switch (armor)
            {
                case (ArmorType.Cloth):
                    Primary.Strength = 2;
                    Primary.Dexterity = 2;
                    Primary.Intelligence = 8;
                    Primary.Vitality = 3;
                    break;

                case (ArmorType.Leather):
                    Primary.Strength = 2;
                    Primary.Dexterity = 7;
                    Primary.Intelligence = 2;
                    Primary.Vitality = 4;
                    break;

                case (ArmorType.Mail):
                    Primary.Strength = 4;
                    Primary.Dexterity = 5;
                    Primary.Intelligence = 1;
                    Primary.Vitality = 5;
                    break;

                case (ArmorType.Plate):
                    Primary.Strength = 6;
                    Primary.Dexterity = 2;
                    Primary.Intelligence = 1;
                    Primary.Vitality = 6;
                    break;
            }
            this.BaseAttributes = Primary;
        }
    }
}
