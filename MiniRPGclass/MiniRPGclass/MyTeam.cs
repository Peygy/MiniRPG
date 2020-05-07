using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class MyTeam
    {
        string Name;
        Bulgar Hero1 = new Bulgar();
        Samur Hero2 = new Samur();
        Djager Hero3 = new Djager();
        Hunter Hero4 = new Hunter();
        List<string> Heroes = new List<string>();// Чтобы не выдавало ошибку, в будующем перенесу
        public void NameTeam(string _name)
        {
            Name = _name;
        }

        public void AddHero(int _indexteam)
        {
            Team.Add(Heroes[_indexteam]);
        }

        public void GetDamage(int index, int count)
        {
            Team[index].GetDamage(count);
        }
        public int TakeDamage(int index)
        {
            return Team[index].DamageTake();
        }
    }
}
