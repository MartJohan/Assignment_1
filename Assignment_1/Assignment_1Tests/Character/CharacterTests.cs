using Xunit;
using System;
using Assignment_1.classes.Heroes;
using Assignment_1.classes.Attributes;

namespace Assignment_1Tests.CharacterTests
{
    public class CharacterTests
    {
        [Fact]
        public void CreateCharacter_LevelShouldBeOne()
        {
            //Arrange
            int expectedLevel = 1;

            //Act
            Warrior actual = new Warrior("Martin");

            //Assert
            Assert.Equal(expectedLevel, actual.Level);
        }

        [Fact]
        public void CharacterLevelUp_LevelShouldBeTwo()
        {
            //Arrange
            int expectedLevel = 2;

            //Act
            Warrior actual = new Warrior("Martin");
            actual.LevelUp();

            //Assert
            Assert.Equal(expectedLevel, actual.Level);
        }

        [Fact]
        public void CreateWarrior_CorrectStartingAttributes()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 5,
                Dexterity = 2,
                Intelligence = 1,
                Vitality = 10
            };

            //Act
            Warrior actual = new Warrior("Martin");

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void CreateRanger_CorrectStartingAttributes()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 1,
                Dexterity = 7,
                Intelligence = 1,
                Vitality = 8
            };

            //Act
            Ranger actual = new Ranger("Martin");

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void CreateRogue_CorrectStartingAttributes()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 2,
                Dexterity = 6,
                Intelligence = 1,
                Vitality = 8
            };

            //Act
            Rogue actual = new Rogue("Martin");

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void CreateMage_CorrectStartingAttributes()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 8,
                Vitality = 5
            };

            //Act
            Mage actual = new Mage("Martin");

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void WarriorLevelUp_CorrectBaseStats()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 8,
                Dexterity = 4,
                Intelligence = 2,
                Vitality = 15
            };

            //Act
            Warrior actual = new Warrior("Martin");
            actual.LevelUp();

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void RangerLevelUp_CorrectBaseStats()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 2,
                Dexterity = 12,
                Intelligence = 2,
                Vitality = 10
            };

            //Act
            Ranger actual = new Ranger("Martin");
            actual.LevelUp();

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void RogueLevelUp_CorrectBaseStats()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 3,
                Dexterity = 10,
                Intelligence = 2,
                Vitality = 11
            };

            //Act
            Rogue actual = new Rogue("Martin");
            actual.LevelUp();

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void MageLevelUp_CorrectBaseStats()
        {
            //Arrange
            Primary expected = new Primary
            {
                Strength = 2,
                Dexterity = 2,
                Intelligence = 13,
                Vitality = 8
            };

            //Act
            Mage actual = new Mage("Martin");
            actual.LevelUp();

            //Assert
            expected.Equals(actual.BaseAttributes);
        }

        [Fact]
        public void WarriorLevelUp_CorrectSecondaryStats()
        {
            //Arrange
            //: Health = 150, ArmorRating = 12, ElementalResistance = 2
            Secondary expected = new Secondary
            {
                Health = 150,
                ArmorRating = 12,
                ElementalResistance = 2
            };

            //Act
            Warrior actual = new Warrior("Martin");
            actual.LevelUp();

            //Assert
            expected.Equals(actual);
        }
    }
}
