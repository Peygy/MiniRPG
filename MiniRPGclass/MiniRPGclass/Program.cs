using System;

namespace MiniRPGclass
{
    class Program
    {
        static void Main(string[] args)
        {
            Bulgar bulgar = new Bulgar("Бандит", 185, 80);
            Samur samur = new Samur("Самурай", 200, 55);
            Hunter hunter = new Hunter("Охотник", 110, 100);
            Djager djager = new Djager("Джагернаут", 700, 35);
        }
    }
}
