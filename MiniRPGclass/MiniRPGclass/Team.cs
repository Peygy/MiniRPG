using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MiniRPGclass
{
    //Броню персонажей и их разброс я сделаю и подредактирую, как завершу основую боёвку и всё такое в GAME.cs...
    //Короче доделать основу сначала, а потом уже браться за косметические дороботки...
    class Team
    {
        public string Name { get; set; }
        protected List<Hero> team;
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
        public string GetHeroName(int NameIndex)
        {
            return team[NameIndex].Name;
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

        public virtual int ChooseHeroTakingDamage(int index, int count)//Метод для получения урона
        {
            return team[index].TakeDamage(count);
        }
        public virtual int ChooseHeroGivingDamage(int index)//Метод для нанесения урона
        {
            return team[index].GiveDamage();
        }
        public string ConclusionHeroes()//Вывод героев
        {
            string output = $"Команда {Name}\n\n";
            for (int i = 0; i < team.Count; i++)
            {
                output += $"{i + 1}. {team[i].Print()}\n";
            }
            return output;
        }
        public bool ChoiceLiving(int num)//Проверка на выбор живого персонажа
        {
            return team[num].Death;
        }
        public bool TeamDeathCheck()
        {
            int i = 0;
            bool Check = true;
            for(int t = 0; t < 3; t++)
            {                
                if (team[t].Death)
                {
                    i++;
                }
            }      
            
            if(i != 3)
            {
                Check = false;
            }           
            return Check;          
        }
    }
}
