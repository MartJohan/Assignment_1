using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.classes.Attributes
{
    public class Secondary
    {
        public int Health { get; set; }

        public int ArmorRating { get; set; }

        public int ElementalResistance { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Secondary secondary &&
                   Health == secondary.Health &&
                   ArmorRating == secondary.ArmorRating &&
                   ElementalResistance == secondary.ElementalResistance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Health, ArmorRating, ElementalResistance);
        }
    }
}
