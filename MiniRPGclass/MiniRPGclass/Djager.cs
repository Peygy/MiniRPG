using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class Djager : Hero
    {
        public int Scatter;
        public bool Death;
        public string Die;
        public Djager(string _name, int _health, int _damage) : base(_name, _health, _damage)
        {
            
        }
    }
}
