using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Assignment_1.classes.Heroes;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Exceptions;

namespace Assignment_1Tests.Items
{
    public class ItemsTests
    {
        Warrior warrior = new Warrior("Martin");

        Weapon axe = new Weapon(2, Weapon.WeaponType.Axe);
        Weapon normalAxe = new Weapon(1, Weapon.WeaponType.Axe);

        Armor plateBody = new Armor(2, Armor.ArmorType.Plate, Assignment_1.classes.Equipment.Items.Slots.Body);
        Armor normalPlateBody = new Armor(1, Armor.ArmorType.Plate, Assignment_1.classes.Equipment.Items.Slots.Body);

        Weapon bow = new Weapon(1, Weapon.WeaponType.Bow);
        Armor clothHead = new Armor(1, Armor.ArmorType.Cloth, Assignment_1.classes.Equipment.Items.Slots.Head);

        [Fact]
        public void EquipHighLevelAxe_ThrowInvalidWeaponException()
        {
            //Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipGear(axe));
        }

        [Fact]
        public void EquipHighLevelArmor_ThrowInvalidArmorException()
        {
            Assert.Throws<InvalidArmorException>(() => warrior.EquipGear(plateBody));
        }

        [Fact]
        public void EquipWrongWeaponType_ThrowInvalidWeaponException()
        {
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipGear(bow));
        }

        [Fact]
        public void EquipWrongArmorType_ThrowInvalidArmorException()
        {
            Assert.Throws<InvalidArmorException>(() => warrior.EquipGear(clothHead));
        }

        [Fact]
        public void EquipWeapon_SuccessMessage()
        {
            //Arrange
            string expected = "New weapon equipped";

            //Act
            string actual = warrior.EquipGear(normalAxe);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_SuccessMessage()
        {
            //Arrange
            string expected = "New armor equipped";

            //Act
            string actual = warrior.EquipGear(normalPlateBody);

            //Assert
            Assert.Equal(expected, actual);
        }

        //DPS Formula : 1 * (1 + class_primary_attribute/100);
        [Fact]
        public void CalculateDPSWithNoWeapon_CorrectDPS()
        {
            //Arrange
            double expected = 1 * (1 + 5 / 100);

            //Act
            double actual = warrior.Damage;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDPSWithWeapon_CorrectDPS()
        {
            //Arrange
            double expected = (7 * 1.1) * (1 + (5 / 100));

            //Act
            warrior.EquipGear(normalAxe);
            double actual = warrior.Damage;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDPSWithWeaponAndArmor_CorrectDPS()
        {
            //Arrange
            double expected = (7 * 1.1) * (1 + ((5 + 1) / 100));

            //Act
            warrior.EquipGear(normalAxe);
            warrior.EquipGear(normalPlateBody);
            double actual = warrior.Damage;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
