using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.classes.Attributes
{
    public class Primary
    {
        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Primary primary &&
                   Strength == primary.Strength &&
                   Dexterity == primary.Dexterity &&
                   Intelligence == primary.Intelligence &&
                   Vitality == primary.Vitality;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Strength, Dexterity, Intelligence, Vitality);
        }
    }
}
