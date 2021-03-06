﻿using System;
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
        public GAME()
        {
            generation = new Random();
            PcTeam = new PCTeam();
            myTeam = new PlayerTeam();
        }

        public void StartGame()
        {
            //Определение имени команды 
            Console.Write("Паридумай имя своей команде: ");
            string name = Console.ReadLine();
            myTeam.NameTeam(name);
            Console.Clear();
            List<string> CompName = new List<string>();
            CompName.Add("Кибран");
            CompName.Add("ЭОН");
            CompName.Add("Конфедерция");
            int randoms = generation.Next(3);
            string compName = CompName[randoms];
            Console.WriteLine($"Компьютер выбрал имя: {compName}, нажмите Enter");
            PcTeam.NameTeam(compName);
            Console.ReadLine();
            Console.Clear();

            //Добавление героев в команды и их вывод
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Bulgar());
            heroes.Add(new Djager());
            heroes.Add(new Samur());
            heroes.Add(new Hunter());
            int i;
            for (i = 0; i < heroes.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                Console.WriteLine(heroes[i].Print());
            }
            i = 0;
            while (i < 3)
            {              
                Console.SetCursorPosition(0, heroes.Count + 2);
                Console.WriteLine("Выбери герой: ");
                int.TryParse(Console.ReadLine(), out int CharactNum);
                if (!myTeam.CheckingTeam(heroes[CharactNum - 1]))
                {
                    myTeam.AddHero(heroes[CharactNum - 1]);
                    i++;
                }
                else
                {
                    Console.SetCursorPosition(0, heroes.Count + 3);
                    Console.Write("У вас уже есть этот герой, Нажмите Enter");
                    Console.ReadLine();
                }
                Console.SetCursorPosition(0, heroes.Count + 3);
                Console.Write("                                              ");
            }
            i = 0;
            while (i < 3)
            {
                int CompCharct = generation.Next(0, 4);
                if (!PcTeam.CheckingTeam(heroes[CompCharct]))
                {
                    PcTeam.AddHero(heroes[CompCharct]);
                    i++;
                }
                
            }
        }

        public void MainGame()//Основная Боёвка
        {
            //attackig - ОН АТАКУЕТ !!!
            //attacked - ЕГО АТАКУЮТ !!!
            Console.Clear();
            while (!myTeam.TeamDeathCheck() && !PcTeam.TeamDeathCheck())
            {
                Console.WriteLine(myTeam.ConclusionHeroes());
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(PcTeam.ConclusionHeroes());

                int PcAttacking = 10;
                int PcAttacked = 0;
                int attacking = 0;
                int attacked = 0;

                bool success = true;
                while (success)
                {
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("Кем атаковать: ");
                    int.TryParse(Console.ReadLine(), out attacking);
                    if (myTeam.ChoiceLiving(attacking - 1))
                    {
                        Console.SetCursorPosition(0, 15);
                        Console.Write("Герой мёртв, выберите другого персонажа. Нажми Enter");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 15);
                        Console.WriteLine("                                                                 ");
                    }
                    else
                    {
                        success = false;
                    }
                }

                success = true;
                while (success)
                {                    
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("Кого атаковать: ");
                    int.TryParse(Console.ReadLine(), out attacked);
                    if (PcTeam.ChoiceLiving(attacked - 1))
                    {
                        Console.SetCursorPosition(0, 17);
                        Console.Write("Герой мёртв, выберите другого персонажа. Нажми Enter");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 17);
                        Console.WriteLine("                                                                ");
                    }
                    else
                    {
                        success = false;
                    }
                }

                success = true;
                while (success)
                {
                    PcAttacking = generation.Next(0, 3);
                    if (!myTeam.ChoiceLiving(PcAttacking))
                    {
                        success = false;
                    }
                }

                success = true;
                while (success)
                {
                    PcAttacked = generation.Next(0, 3);
                    if (!myTeam.ChoiceLiving(PcAttacked))
                    {
                        success = false;
                    }
                }

                //Атака человека:
                Console.WriteLine();
                PcTeam.ChooseHeroTakingDamage(attacked - 1, myTeam.ChooseHeroGivingDamage(attacking));
                //Атака компа:
                myTeam.ChooseHeroTakingDamage(PcAttacked, PcTeam.ChooseHeroGivingDamage(PcAttacking));
                //Вывод:
                Console.Clear();
                Console.WriteLine($"{myTeam.GetHeroName(attacking - 1)} ({myTeam.Name}) нанёс {myTeam.ChooseHeroGivingDamage(attacking)} " +
                                  $"единиц урона {PcTeam.GetHeroName(attacked - 1)} ({PcTeam.Name})");
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"{PcTeam.GetHeroName(PcAttacking)} ({PcTeam.Name}) нанёс {PcTeam.ChooseHeroGivingDamage(PcAttacking)} " +
                                  $"единиц урона {myTeam.GetHeroName(PcAttacked)} ({myTeam.Name})");;
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void EndGame()
        {
            string check = null;
            if (myTeam.TeamDeathCheck() && PcTeam.TeamDeathCheck())
            {
                check = "Ничья)";
            }
            else
            {
                check = PcTeam.TeamDeathCheck() ? $"Победила команда {myTeam.Name}" : $"Победила команда {PcTeam.Name}";
            }
            Console.WriteLine(check);
        }
    }
}
