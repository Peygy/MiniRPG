using System;
using System.Collections.Generic;

namespace MiniRPGclass
{
    class Program
    {
        static string CompName()
        {
            Random generation = new Random();
            List<string> CompName = new List<string>();
            CompName.Add("Кибран");
            CompName.Add("ЭОН");
            CompName.Add("Конфедерция");
            int randoms = generation.Next(1, 4);
            string compName = CompName[randoms];
            return compName;
        }
        static void Main(string[] args)
        {
            MyTeam team = new MyTeam();
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Hero("Бандит", 185, 80));
            heroes.Add(new Hero("Самурай", 200, 55));
            heroes.Add(new Hero("Охотник", 110, 100));
            heroes.Add(new Hero("Джагернаут", 700, 35));

            Console.Write("Паридумай имя своей команде: ");
            string name = Console.ReadLine();
            team.NameTeam(name);
            Console.Clear();

            Console.WriteLine($"Компьютер выбрал имя: {CompName()}");
            Console.ReadLine();
            Console.Clear();

            bool end = true;
            while (end)
            {
                Console.WriteLine("Выберите 3-х персонажей из списка:");
                for (int i = 0; i < heroes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {[i]} ({[i]}НР), базовый урон: {Damage[i]}");
                }
                int.TryParse(Console.ReadLine(), out int input);
                team.AddHero(input);
                Console.Clear();
            }
        }
    }
}
