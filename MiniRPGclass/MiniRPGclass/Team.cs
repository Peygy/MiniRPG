using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    //Броню персонажей и их разброс я сделаю и подредактирую, как завершу основую боёвку и всё такое в GAME.cs...
    //Короче доделать основу сначала, а потом уже браться за косметические дороботки...
    class Team
    {
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
        public bool CheckingTeam(Hero CharactNum)//Проверка на нахождение в команде
        {
            if (team.Contains(CharactNum))
            {
                return true;
            }
            else
            {
                return false;
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
                team[i].Print();
            }
        }
        public bool ChoiceLiving(int num)//Проверка на выбор живого персонажа
        {
            return team[num].Death;
        }
        public bool EndCheck()
        {
            bool Check = true;
            if(!team[0].Death && !team[1].Death && !team[2].Death)
            {
                return Check;
            }
            else
            {
                Check = false;
                return Check;
            }
        }
        public void DeathMessage(int attack)//Выводит сообщенеи о смерти(сделал здесь, т.к с командой есть вопрос, как к ней обратиться)
        {
            Console.SetCursorPosition(0, 15);
            Console.Write($"{team[attack - 1]} -  мёртв, выберите другого персонажа");//Вот здесь...
            Console.ReadLine();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("                                                             " +
                              "                              ");
            Console.SetCursorPosition(0, 15);
        }
    }
}
