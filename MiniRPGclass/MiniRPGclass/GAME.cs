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
            heroes.Add(new Bulgar());
            heroes.Add(new Djager());
            heroes.Add(new Samur());
            heroes.Add(new Hunter());
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
                if(!myTeam.CheckingTeam(heroes[CharactNum - 1]))
                {
                    myTeam.AddHero(heroes[CharactNum - 1]);
                    l++;
                }
            }
            while (i < 3)
            {
                int CompCharct = generation.Next(0, 4);
                if(!PcTeam.CheckingTeam(heroes[CompCharct]))
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
            while (myTeam.TeamDeathCheck() && PcTeam.TeamDeathCheck())
            {
                myTeam.ConclusionHeroes();
                Console.WriteLine();
                Console.WriteLine();
                PcTeam.ConclusionHeroes();

                int PcAttacking = 0;
                int PcAttacked = 0;
                int attacking = 0;
                int attacked = 0;
                bool success = true;
                while (success)
                {
                    Console.WriteLine("Кем атаковать: ");
                    int.TryParse(Console.ReadLine(), out attacking);
                    if (myTeam.ChoiceLiving(attacking))
                    {
                        Console.SetCursorPosition(0, 15);
                        Console.Write("Герой мёртв, выберите другого персонажа. Нажми Enter");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 15);
                        Console.WriteLine("                                                             " +
                                          "                                                             ");
                        Console.SetCursorPosition(0, 15);
                    }
                    else
                    {
                        success = false;
                    }
                }

                while (success)
                {
                    Console.WriteLine("Кого атаковать: ");
                    int.TryParse(Console.ReadLine(), out attacked);
                    if (PcTeam.ChoiceLiving(attacked))
                    {
                        Console.SetCursorPosition(0, 15);
                        Console.Write("Герой мёртв, выберите другого персонажа. Нажми Enter");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 15);
                        Console.WriteLine("                                                             " +
                                          "                                                             ");
                        Console.SetCursorPosition(0, 15);
                    }
                    else
                    {
                        success = false;
                    }
                }

                while (success)
                {
                    PcAttacking = generation.Next(0, 3);
                    if (!PcTeam.ChoiceLiving(PcAttacking))
                    {
                        success = false;
                    }
                }
                while (success)
                {
                    PcAttacked = generation.Next(0, 3);
                    if (!PcTeam.ChoiceLiving(PcAttacked))
                    {
                        success = false;
                    }
                }

                //Атака человека:
                Console.WriteLine();   
                PcTeam.ChooseHeroTakingDamage(attacked, 
                    myTeam.ChooseHeroGivingDamage(attacking));
                //Атака компа:
                myTeam.ChooseHeroTakingDamage(PcAttacked,
                    PcTeam.ChooseHeroGivingDamage(PcAttacking));
                //Вывод:
                Console.Clear();
                Console.WriteLine($"{myTeam.GetName(attacking)} ({myTeam.Name}) нанёс {myTeam.ChooseHeroGivingDamage(attacking)} " +
                                  $"едениц урона {PcTeam.GetName(attacked)} ({PcTeam.Name})");
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"{PcTeam.GetName(PcAttacking)} ({PcTeam.Name}) нанёс {PcTeam.ChooseHeroGivingDamage(PcAttacking)} " +
                                  $"едениц урона {myTeam.GetName(PcAttacked)} ({myTeam.Name})");;
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
