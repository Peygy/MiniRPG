using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPGclass
{
    class PCTeam : Team
    {
        public override int ChoiceLivingAttacking()//Проверка на выбор живого персонажа(который бьёт)
        {
            bool compAttacking = true;
            while (compAttacking)
            {
                Attacking = generation.Next(0, 3);
                bool acceptAttackComp = CompDead[Attacking] != " ";//Как сюда поместить проверку на сметрь
                if (acceptAttackComp)
                {
                    Console.Write("");
                }
                else
                {
                    compAttacking = false;
                }
            }
        }

        public override int ChoiceLivingAttacked()//Проверка на выбор живого персонажа(которого бьют)
        {
            bool compAttacked = true;
            while (compAttacked)
            {
                Attacked = generation.Next(0, 3);
                bool acceptAttackComp = MyDead[Attacked] != " ";//Как сюда поместить проверку на сметрь
                if (acceptAttackComp)
                {
                    Console.Write("");
                }
                else
                {
                    compAttacked = false;
                }
            }
        }
    }
}
