using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class Samur : Hero
    {
        public int Scatter;
        public bool Death;
        public string Die;
        public Samur(string _name, int _health, int _damage) : base(_name, _health, _damage)
        {
            
        }
    }
}
