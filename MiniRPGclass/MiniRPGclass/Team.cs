using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class Team
    {
        protected string Name { get; set; }
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
    }
}
