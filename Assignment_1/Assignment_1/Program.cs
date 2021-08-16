using System;
using Assignment_1.classes.Heroes;
using Assignment_1.classes.Equipment;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Mage hero = new Mage("Martin");
            hero.LevelUp();
            hero.Display();
        }
    }
}
