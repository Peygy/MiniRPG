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
            team.NameTeam(name);
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
            Console.ReadLine();
            Console.Clear();
        }
        public void HeroesList()//Вывод всех героев
        {
            Hero heroClass = new Hero();
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {heroClass.Print(i)}");//Как програм. определит характер. какого перса. вывести->Hero.cs
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
                bool accept = MyTeam.Contains(heroes[CharactNum - 1]);//?
                if (!accept)
                {
                    myTeam.AddHeroPlayer(heroes[CharactNum - 1]);
                    l++;
                }                
            }
            while (i < 3)
            {
                int CompCharct = generation.Next(0, 4);
                bool accept = ComputerTeam.Contains(heroes[CompCharct]);//?
                if (!accept)
                {
                    PcTeam.AddHeroPC(heroes[CompCharct]);
                }
            }
        }

        public void MainGame()//Основная Боёвка(НЕДОДЕЛАНА)
        {
            Console.Clear();
            while (MyDeath != 3 || PCDeaths != 3)
            {
                Console.WriteLine($"Команда {team.Name}");//? 
                Console.WriteLine();
                for (int i = 0; i < MyTeam.Count; i++)//?
                {
                    Console.WriteLine($"{i + 1}. {MyTeam.Print(i)}");//Выведет ли так характ. персон. из команды
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Команда {compName}");
                Console.WriteLine();
                for (int i = 0; i < ComputerTeam.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ComputerTeam.Print(i)}");
                }

                //attackig - ОН АТАКУЕТ !!!
                //attacked - ЕГО АТАКУЮТ !!!

                Console.WriteLine();
                bool whomAttack = true;
                while (whomAttack)
                {
                    Console.WriteLine("Кем атаковать: ");
                    int.TryParse(Console.ReadLine(), out int attacking);
                    bool acceptAttack = MyDeath[attacking - 1] != " ";
                    if (acceptAttack)
                    {
                        Console.SetCursorPosition(0, 15);
                        Console.Write($"{MyTeam[attacking - 1]} -  мёртв, выберите другуго персонажа");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 15);
                        Console.WriteLine("                                                             " +
                                          "                              ");
                        Console.SetCursorPosition(0, 15);
                    }
                    else
                    {
                        whomAttack = false;
                    }
                }

                Console.WriteLine();
                bool whoAttack = true;
                while (whoAttack)
                {
                    Console.WriteLine("Кого атаковать: ");
                    int.TryParse(Console.ReadLine(), out int attacked);
                    bool acceptAttack = PCDeath[attacked - 1] != " ";
                    if (acceptAttack)
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.Write($"{ComputerTeam[attacked - 1]} - мёртв, выберите другуго персонажа");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 18);
                        Console.WriteLine("                                                              " +
                                          "                             ");
                        Console.SetCursorPosition(0, 18);
                    }
                    else
                    {
                        whoAttack = false;
                    }
                }

                // ДАЛЬШЕ ВСЁ КАК БЫЛО...
                CompHealth[attacked - 1] = CompHealth[attacked - 1] - MyDamage[attacking - 1];

                if (CompHealth[attacked - 1] <= 0)
                {
                    CompHealth[attacked - 1] = 0;
                    compDeaths++;
                    CompDead[attacked - 1] = " - мёртв";
                }

                bool compAttacking = true;
                while (compAttacking)
                {
                    CoAttacking = generation.Next(0, 3);
                    bool acceptAttackComp = CompDead[CoAttacking] != " ";
                    if (acceptAttackComp)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        compAttacking = false;
                    }
                }

                bool compAttacked = true;
                while (compAttacked)
                {
                    CoAttacked = generation.Next(0, 3);
                    bool acceptAttackComp2 = MyDead[CoAttacked] != " ";
                    if (acceptAttackComp2)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        compAttacked = false;
                    }
                }

                MyHealth[CoAttacked] = MyHealth[CoAttacked] - CompDamage[CoAttacking];

                if (MyHealth[CoAttacked] <= 0)
                {
                    MyHealth[CoAttacked] = 0;
                    MyDead.Add(MyCharact[CoAttacked]);
                    MyDeath++;
                    MyDead[CoAttacked] = " - мёртв";
                }


                Console.Clear();
                Console.WriteLine($"{MyCharact[attacking - 1]} ({name}) нанёс {MyDamage[attacking - 1]} " +
                                  $"едениц урона {CompCharact[attacked - 1]} ({compName})");
                Console.WriteLine($"{CompCharact[attacked - 1]}{CompDead[attacked - 1]}. ");
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();


                Console.WriteLine($"{CompCharact[CoAttacking]} ({compName}) нанёс {CompDamage[CoAttacking]} " +
                                  $"едениц урона {MyCharact[CoAttacked]} ({name})");
                Console.WriteLine($"{MyCharact[CoAttacked]}{MyDead[CoAttacked]}. ");
                Console.Write("Нажмите Enter...");
                Console.ReadLine();
                Console.Clear();

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
                    Console.WriteLine($"Победила команда {name}");
                }
                else
                {
                    Console.WriteLine($"Победила команда {compName}");
                }
            }

        }
    }
}
