using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class PlayerTeam : Team
    {
        public override int ChooseHeroTakingDamage(int index, int count)//Выбор персонажа для получения урона
        {
            return team[index].TakeDamage(count);
        }
        public override int ChooseHeroGivingDamage(int index)//Выбор персонажа для нанесения урона
        {
            Random generation = new Random();
            int Scatter = generation.Next(-10, 11);
            index--;
            return team[index].GiveDamage() + Scatter;
        }
    }
}
