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

        public void Print(int index)//Вывод характеристик героя
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
            Console.WriteLine($"Имя: {Name[index]} {Die}, Здоровье: {Health[index]}, Базовый урон: {Damage[index]}");
        }

        public int TakeDamage(int GetDamage)//Метод для получения урона
        {
            Health = Health - GetDamage;
            return Health;
        }
        public int GiveDamage()//Метод для нанесения урона 
        {
            int Scatter = gener.Next(-10, 11);
            Damage = Damage + Scatter;
            return Damage;
        }
    }
}
