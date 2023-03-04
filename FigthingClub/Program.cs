using FigthingClub.Fighters;
using System;

namespace FigthingClub
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
        }
        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Игра БОЙЦОВСКИЙ КЛУБ\n");
            Console.WriteLine("1 - Начать игру");
            Console.WriteLine("2 - Правила");
            Console.WriteLine("3 - Выход");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Game game = new Game();
                game.StartGame();
            }
            if (option == "2")
                PrintRules();
            if (option == "3")
                return; 
            PrintMenu();
        }
        static void PrintRules()
        {
            Console.Clear();
            Console.WriteLine(new Warrior());
            Console.WriteLine(new Dodger());
            Console.WriteLine(new Mage());
            Console.ReadLine();
        }
    }
}
