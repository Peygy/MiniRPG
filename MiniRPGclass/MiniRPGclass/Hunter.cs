﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class Hunter : Hero
    {
        public Hunter() : base()
        {
            Name = "Охотник";
            Health = 110;
            Damage = 100;
        }
    }
}
