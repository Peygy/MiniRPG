using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiniRPGclass
{
    
    class GAME
    {
        Random generation;
        PlayerTeam myTeam;
        PCTeam PcTeam;
        List<Hero> heroes;
        public GAME()
        {
            generation = new Random();
            PcTeam = new PCTeam();
            myTeam = new PlayerTeam();
            heroes = new List<Hero>();
            heroes.Add(new Bulgar());
            heroes.Add(new Djager());
            heroes.Add(new Samur());
            heroes.Add(new Hunter());
        }

        public void ChooseName()// Определение имени команды 
        {
            Console.Write("Паридумай имя своей команде: ");
            string name = Console.ReadLine();
            myTeam.NameTeam(name);
            Console.Clear();
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

        public void AddingHero()//Добавление героев в команды и их вывод
        {
            for (int k = 0; k < heroes.Count; k++)
            {
                Console.Write($"{k + 1}. ");
                heroes[k].Print();
            }
            int l = 0;
            int i = 0;
            while (l < 3)
            {                
                Console.SetCursorPosition(0, heroes.Count + 2);
                Console.Write("                          ");
                Console.SetCursorPosition(0, heroes.Count + 2);
                Console.WriteLine("Выбери персонажа: ");
                int.TryParse(Console.ReadLine(), out int CharactNum);
                myTeam.CheckingTeam(heroes[CharactNum]);
                myTeam.AddHero(heroes[CharactNum]);
            }
            while (i < 3)
            {
                int CompCharct = generation.Next(0, 4);
                PcTeam.CheckingTeam(heroes[CompCharct]);
                PcTeam.AddHero(heroes[CompCharct]);
            }
        }
   
        public void MainGame()//Основная Боёвка(НЕДОДЕЛАНА)
        {
            //attackig - ОН АТАКУЕТ !!!
            //attacked - ЕГО АТАКУЮТ !!!
            Console.Clear();
            while ( )//Не понял как обратиться к героям и узнать мёртв ли он
            {
                myTeam.ConclusionHeroes();
                Console.WriteLine();
                Console.WriteLine();
                PcTeam.ConclusionHeroes();

                bool success = true;
                while (success)
                {
                    Console.WriteLine("Кем атаковать: ");
                    int.TryParse(Console.ReadLine(), out int attack);
                    if (myTeam.ChoiceLiving(attack))
                    {
                        myTeam.DeathMessage(attack);
                    }
                    else
                    {
                        success = false;
                    }
                }

                while (success)
                {
                    Console.WriteLine("Кого атаковать: ");
                    int.TryParse(Console.ReadLine(), out int attack);
                    if (PcTeam.ChoiceLiving(attack))
                    {
                        PcTeam.DeathMessage(attack);
                    }
                    else
                    {
                        success = false;
                    }
                }
                //Дальше не понял, как из двух циклов выше вывести ATTACK
                //Атака человека:
                Console.WriteLine();   
                PcTeam.ChooseHeroTakingDamage(PcTeam.ChoiceLiving(), 
                    myTeam.ChooseHeroGivingDamage(myTeam.ChoiceLiving()));
                //Атака компа:
                myTeam.ChooseHeroTakingDamage(myTeam.ChoiceLiving(),
                    PcTeam.ChooseHeroGivingDamage(PcTeam.ChoiceLiving()));
                //Вывод:
                Console.Clear();
                Console.WriteLine($"{myTeam[ChoiceLivingAttacking()]} ({myTeam.Name}) нанёс {ChooseHeroGivingDamage(ChoiceLivingAttacking())} " +
                                  $"едениц урона {PcTeam.[ChoiceLivingAttacked()]} ({PcTeam.Name})");
                Console.WriteLine($"{PcTeam[ChoiceLiving()]}. ");
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();

                Console.Clear();
                Console.WriteLine($"{PcTeam[ChoiceLivingAttacking()]} ({PcTeam.Name}) нанёс {ChooseHeroGivingDamage(ChoiceLivingAttacking())} " +
                                  $"едениц урона {myTeam[ChoiceLivingAttacked()]} ({myTeam.Name})");
                Console.WriteLine($"{myTeam[ChoiceLiving()]}. ");
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void EndGame()
        {
            if ( )
            {
                Console.WriteLine("Ничья))");
            }
            else
            {
                if ( ) 
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
