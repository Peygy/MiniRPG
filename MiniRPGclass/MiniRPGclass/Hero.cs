using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MiniRPGclass
{
    class Hero
    {
        Random gener = new Random();
        public string Name;
        public int Health;
        public int Damage;
        public int GetDamage;
        public int Scatter;
        public bool Death;
        public string Die;
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

        public int TakeDamage()
        {
            Health = Health - GetDamage;
            return Health;
        }
        public int GiveDamage()
        {
            Scatter = gener.Next(-10, 10);
            Damage = Damage + Scatter;
            return Damage;
        }
    }
}
