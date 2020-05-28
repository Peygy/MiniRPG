using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class PCTeam : Team
    {
        protected string PCName { get; set; }
        List<Hero> ComputerTeam;
        List<Hero> PCDeath;
        public PCTeam()
        {
            ComputerTeam = new List<Hero>();
            PCDeath = new List<Hero>();
        }
        public void NameTeamPC(string _name)//Установка имени команды
        {
            PCName = _name;
        }
        public void AddHeroPC(Hero AddingHero)//Добавление героя в команду
        {
            ComputerTeam.Add(AddingHero);
            PCDeath.Add(AddingHero);
        }
        public int ChooseHeroTakingDamagePK(int index, int count)//Выбор персонажа для получения урона
        {
            return ComputerTeam[index].TakeDamage(count);
        }
        public int ChooseHeroGivingDamagePK(int index)//Выбор персонажа для нанесения урона
        {
            return ComputerTeam[index].GiveDamage();
        }
    }
}
