using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class MyTeam
    {
        protected string Name;
        List<Hero> myTeam = new List<Hero>();
        public void NameTeam(string _name)
        {
            Name = _name;
        }

        public void AddHero(int input)
        {
            input = input - 1;
            myTeam.Add(heroes[input]);
        }

        public void GetDamage(int index, int count)
        {
            myTeam[index].GetDamage(count);
        }
        public int TakeDamage(int index)
        {
            return myTeam[index].TakeDamage();
        }
    }
}
