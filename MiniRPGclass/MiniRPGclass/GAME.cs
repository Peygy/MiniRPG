using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiniRPGclass
{
    class GAME
    {
        int MyDeath = 0;
        int PCDeaths = 0;
        Random generation = new Random();
        Team team = new Team();
        PlayerTeam myTeam = new PlayerTeam();
        PCTeam PcTeam = new PCTeam();
        List<Hero> heroes;
        public GAME()
        {
            heroes = new List<Hero>();
        }
        public void ChoosePlayerName()// Определение имени команды игрока
        {
            Console.Write("Паридумай имя своей команде: ");
            string name = Console.ReadLine();
            myTeam.NameTeam(name);
            Console.Clear();
        }
        public void ChooseCompName()// Определение имени команды ПК
        {            
            List<string> CompName = new List<string>();
            CompName.Add("Кибран");
            CompName.Add("ЭОН");
            CompName.Add("Конфедерция");
            int randoms = generation.Next(1, 4);
            string compName = CompName[randoms];
            Console.WriteLine($"Компьютер выбрал имя: {compName}");
            PcTeam.NameTeam(compName);
            Console.ReadLine();
            Console.Clear();
        }
        public void HeroesList()//Вывод всех героев
        {
            Hero heroClass = new Hero();
            heroes.Add(new Bulgar());
            heroes.Add(new Djager());
            heroes.Add(new Samur());
            heroes.Add(new Hunter());
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                heroClass.Print();
            }
        }
        public void AddingHero()//Добавление героев в команды(для внешнего). Сами методы добавления в классах команд
        {
            int l = 0;
            int i = 0;
            while (l < 3)
            {                
                Console.SetCursorPosition(0, heroes.Count + 2);
                Console.Write("                          ");
                Console.SetCursorPosition(0, heroes.Count + 2);
                Console.WriteLine("Выбери персонажа: ");
                int.TryParse(Console.ReadLine(), out int CharactNum);
                myTeam.CheckingTeam(CharactNum);

            }
            while (i < 3)
            {
                int CompCharct = generation.Next(0, 4);
                PcTeam.CheckingTeam(CompCharct);
            }
        }

        public void MainGame()//Основная Боёвка(НЕДОДЕЛАНА)
        {
            //attackig - ОН АТАКУЕТ !!!
            //attacked - ЕГО АТАКУЮТ !!!
            Console.Clear();
            while (MyDeath != 3 || PCDeaths != 3)
            {
                myTeam.ConclusionHeroes();
                Console.WriteLine();
                Console.WriteLine();
                PcTeam.ConclusionHeroes();

                Console.WriteLine();
                myTeam.ChoiceLivingAttacking();

                //Атака человека:
                Console.WriteLine();
                PcTeam.ChoiceLivingAttacked();
                PcTeam.ChooseHeroTakingDamage(PcTeam.ChoiceLivingAttacked(), 
                    myTeam.ChooseHeroGivingDamage(myTeam.ChoiceLivingAttacking()));
                //Атака компа:
                PcTeam.ChoiceLivingAttacking();
                PcTeam.ChoiceLivingAttacked();

                myTeam.ChooseHeroTakingDamage(myTeam.ChoiceLivingAttacked(),
                    PcTeam.ChooseHeroGivingDamage(PcTeam.ChoiceLivingAttacking()));              
                //Вывод:
               
            }
        }
        public void EndGame()
        {
            if (PCDeaths == 3 && MyDeath == 3)
            {
                Console.WriteLine("Ничья))");
            }
            else
            {
                if (PCDeaths == 3)
                {
                    Console.WriteLine($"Победила команда {myTeam.Name}");
                }
                else
                {
                    Console.WriteLine($"Победила команда {PcTeam.Name}");
                }
            }

        }
    }
}
