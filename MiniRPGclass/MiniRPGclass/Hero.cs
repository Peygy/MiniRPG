using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MiniRPGclass
{
    class Hero
    {
        Random gener;
        protected string Name { set; get; }
        protected int Health { set; get; }
        protected int Damage { set; get; }
        public bool Death { set; get; }
        public Hero()
        {
            gener = new Random();
            Death = true;
        }
        public void DeathCheck()//Проверка на смерть
        {
            if(Health <= 0)
            {
                Health = 0;
                Death = false;              
            }
            else
            {
                Death = true;
            }
        }
        public void Print()//Вывод характеристик героя
        {            
            string Die = Death ? " " : " - мёртв";
            Console.WriteLine($"Имя: {Name} {Die}, Здоровье: {Health}, Базовый урон: {Damage}");
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
