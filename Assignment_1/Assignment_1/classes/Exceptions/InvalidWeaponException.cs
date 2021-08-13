using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Heroes;

namespace Assignment_1.classes.Exceptions
{
    class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
        }

        public InvalidWeaponException(string message) : base(message)
        {
            //Can i remove this? :)(:
        }

        public InvalidWeaponException(Hero hero, Weapon weapon)
        {
            Console.WriteLine($"While being a {hero.Role} you cannot equip a {weapon.Name}, sucks to suck :)");
        }
    }
}
