using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class PlayerTeam : Team
    {
        List<Hero> MyTeam;
        public PlayerTeam()
        {
            MyTeam = new List<Hero>();
        }
        public int ChooseHeroTakingDamagePlayer(int index, int count)//Выбор персонажа для получения урона
        {
            return MyTeam[index].TakeDamage(count);
        }
        public int ChooseHeroGivingDamagePlayer(int index)//Выбор персонажа для нанесения урона
        {
            return MyTeam[index].GiveDamage();
        }
    }
}
