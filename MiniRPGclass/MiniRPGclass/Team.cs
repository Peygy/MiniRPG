using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    //Броню персонажей и их разброс я сделаю и подредактирую, как завершу основую боёвку и всё такое в GAME.cs...
    //Короче доделать основу сначала, а потом уже браться за косметические дороботки...
    class Team
    {
        Hero heroClass = new Hero();
        public string Name { get; set; }
        List<Hero> team;
        public Team()
        {
            team = new List<Hero>();
        }
        public void NameTeam(string _name)//Установка имени команды
        {
            Name = _name;
        }
        public void AddHero(Hero AddingHero)//Добавление героя в команду
        {
            team.Add(AddingHero);
        }
        public void CheckingTeam(int CharactNum)//Проверка на нахождение в команде
        {
            bool accept = team.Contains(heroes[CharactNum - 1]);//Как добавить лист heroes???
            if (!accept)
            {
                team.AddHero(heroes[CharactNum - 1]);
            }
        }

        public int ChooseHeroTakingDamage(int index, int count)//Выбор персонажа для получения урона
        {
            return team[index].TakeDamage(count);
        }
        public int ChooseHeroGivingDamage(int index)//Выбор персонажа для нанесения урона
        {
            return team[index].GiveDamage();
        }

        public void ConclusionHeroes()//Вывод героев
        {
            Console.WriteLine($"Команда {Name}");
            Console.WriteLine();
            for (int i = 0; i < team.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                heroClass.Print();
            }
        }

        public virtual int ChoiceLivingAttacking()//Проверка на выбор живого персонажа(который бьёт)
        {
            bool whomAttack = true;
            while (whomAttack)
            {
                Console.WriteLine("Кем атаковать: ");
                int.TryParse(Console.ReadLine(), out int attacking);
                bool acceptAttack = heroClass.DeathCheck()[attacking - 1] != " ";//Как сюда поместить проверку на сметрь
                if (acceptAttack)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.Write($"{team[attacking - 1]} -  мёртв, выберите другуго персонажа");
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
                //Как сюда правильно return поместить, а то ошибку всегда выдаёт
            }
        }

        public virtual int ChoiceLivingAttacked()//Проверка на выбор живого персонажа(которого бьют)
        {
            bool whoAttack = true;
            while (whoAttack)
            {
                Console.WriteLine("Кого атаковать: ");
                int.TryParse(Console.ReadLine(), out int attacked);
                bool acceptAttack = heroClass.DeathCheck[attacked - 1] != " ";//Как сюда поместить проверку на сметрь
                if (acceptAttack)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.Write($"{team[attacked - 1]} - мёртв, выберите другуго персонажа");
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
                //Как сюда правильно return поместить, а то ошибку всегда выдаёт
            }
        }

        public void TotalOfGame()
        {
            Console.Clear();
            Console.WriteLine($"{team[ChoiceLivingAttacking()]} ({Name}) нанёс {ChooseHeroGivingDamage(ChoiceLivingAttacking())} " +
                              $"едениц урона {team[ChoiceLivingAttacked()]} ({Name})");
            Console.WriteLine($"{team[ChoiceLivingAttacked()]}. ");
            Console.Write("Нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
