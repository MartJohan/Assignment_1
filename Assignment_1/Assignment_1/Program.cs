using System;
using Assignment_1.classes.Heroes;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior war = new Warrior("Martin", 3);
            war.Display();
            war.LevelUp();
            war.Display();
        }
    }
}
