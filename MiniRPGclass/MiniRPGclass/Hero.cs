using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MiniRPGclass
{
    class Hero
    {
        Random gener = new Random();
        protected string Name;
        protected int Health;
        protected int Damage;
        protected bool Death;
        protected string Die;
        public Hero(string _name, int _health, int _damage)
        {
            Name = _name;
            Health = _health;
            Damage = _damage;
        }

        public void Print()
        {
            if (Health < 0)
            {
                Health = 0;
                Die = "- мёртв";
            }
            else
            {
                Die = String.Empty;
            }
            Console.WriteLine($"Имя: {Name} {Die}");
            Console.WriteLine($"Здоровье: {Health}");
            Console.WriteLine($"Базовый урон: {Damage}");
        }

        public int TakeDamage(int GetDamage)
        {
            Health = Health - GetDamage;
            return Health;
        }
        public int GiveDamage()
        {
            int Scatter = gener.Next(-10, 11);
            Damage = Damage + Scatter;
            return Damage;
        }
    }
}
