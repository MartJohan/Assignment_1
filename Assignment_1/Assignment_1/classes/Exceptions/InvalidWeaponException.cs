using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Heroes;

namespace Assignment_1.classes.Exceptions
{
    public class InvalidWeaponException : Exception
    {

        public InvalidWeaponException() { }

        public InvalidWeaponException(string message) : base(message)
        { }

    }
}
