using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class PlayerTeam : Team
    {
        public override int ChooseHeroTakingDamage(int index, int count)//Выбор персонажа для получения урона
        {
            index--;
            return team[index].TakeDamage(count);
        }
        public override int ChooseHeroGivingDamage(int index)//Выбор персонажа для нанесения урона
        {
            index--;
            return team[index].GiveDamage();
        }
    }
}
