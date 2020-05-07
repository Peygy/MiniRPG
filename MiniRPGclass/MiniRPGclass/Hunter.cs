using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class Hunter : Hero
    {
        public int Scatter;
        public bool Death;
        public string Die;
        public Hunter(string _name, int _health, int _damage) : base(_name, _health, _damage)
        {
            
        }
    }
}
