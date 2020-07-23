using System;
using System.Collections.Generic;

namespace MiniRPGclass
{
    class Program
    {       
        static void Main(string[] args)
        {
            GAME part1 = new GAME();
            part1.StartGame();
            part1.MainGame();
            part1.EndGame();
        }
    }
}
