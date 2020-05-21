using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class GAME
    {
        Team team = new Team();
        List<Hero> heroes;
        public string CompName()//Список имён команды ПК
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
        public GAME()
        {
            heroes = new List<Hero>();
        }
        public void Heroes()//Добавление характеристики героев
        {
            heroes.Add(new Hero("Бандит", 185, 80));
            heroes.Add(new Hero("Самурай", 200, 55));
            heroes.Add(new Hero("Охотник", 110, 100));
            heroes.Add(new Hero("Джагернаут", 700, 35));
        }
        public void ChoosePlayerName()// Определение имени команды игрока
        {
            Console.Write("Паридумай имя своей команде: ");
            string name = Console.ReadLine();
            team.NameTeam(name);
            Console.Clear();
        }
        public void ChooseCompName()// Определение имени команды ПК
        {
            Console.WriteLine($"Компьютер выбрал имя: {CompName()}");
            Console.ReadLine();
            Console.Clear();
        }
        public void HeroesList()
        {
            Hero heroClass = new Hero();
            for (int i = 0; i < heroes.Count; i++)
            {
                heroClass.Print(i);
            }
        }
        public void EndGame()
        {

        }
    }
}
