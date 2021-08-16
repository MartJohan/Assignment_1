using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.classes.Equipment
{
    public class Items
    {
        
        public string Name { get; set; }

        //RequiredLevel represents the level needed from the player
        public int RequiredLevel { get; set; }

        public Slots Slot { get; set; }

        public enum Slots
        {
            Head,
            Body,
            Legs,
            Weapon
        }
    }
}
