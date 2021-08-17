using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.classes.Equipment;
using Assignment_1.classes.Heroes;

namespace Assignment_1.classes.Exceptions
{
    public class InvalidArmorException : Exception
    {

        public InvalidArmorException() { }

        public InvalidArmorException(string message) : base(message) { }
    }
}
