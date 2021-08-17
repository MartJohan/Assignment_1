using System;
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
                    Primary.Strength = 0;
                    Primary.Dexterity = 0;
                    Primary.Intelligence = 2;
                    Primary.Vitality = 1;
                    break;

                case (ArmorType.Leather):
                    Primary.Strength = 0;
                    Primary.Dexterity = 2;
                    Primary.Intelligence = 0;
                    Primary.Vitality = 1;
                    break;

                case (ArmorType.Mail):
                    Primary.Strength = 1;
                    Primary.Dexterity = 0;
                    Primary.Intelligence = 0;
                    Primary.Vitality = 2;
                    break;

                case (ArmorType.Plate):
                    Primary.Strength = 1;
                    Primary.Dexterity = 0;
                    Primary.Intelligence = 0;
                    Primary.Vitality = 2;
                    break;
            }
            BaseAttributes = Primary;
        }
    }
}
