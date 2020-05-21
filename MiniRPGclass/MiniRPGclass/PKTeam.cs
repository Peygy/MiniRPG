using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class PKTeam : Team
    {
        List<Hero> ComputerTeam;
        public PKTeam()
        {
            ComputerTeam = new List<Hero>();
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
