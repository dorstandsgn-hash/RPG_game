<<<<<<< HEAD:RPG_game/ConsoleApp1/Weapon.cs
﻿namespace TextRPG
{
    /// <summary>
    /// Базовий клас зброї
    /// </summary>
    public abstract class Weapon : Item, IEquippable
    {
        public int Damage { get; protected set; }

        protected Weapon(string name, string description, int damage)
            : base(name, description)
=======
﻿using System;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static RPG_game.Enemy;

namespace RPG_game
{
    public class Weapon : Item, IEquippable
    {
        public int Damage { get; protected set; }
        public Weapon(string name, string description, int damage) : base(name, description)
>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Weapon.cs
        {
            Damage = damage;
        }

<<<<<<< HEAD:RPG_game/ConsoleApp1/Weapon.cs
        public override void Use(Player player)
        {
            Console.WriteLine($"🗡️ {player.Name} екіпірує {Name}!");
            Equip(player);
        }

        public virtual void Equip(Player player)
        {
            Console.WriteLine($"✅ {Name} екіпіровано! (+{Damage} до атаки)");
        }

        public virtual void Unequip(Player player)
        {
            Console.WriteLine($"❌ {Name} знято.");
        }
    }

    public class GoldSword : Weapon
    {
        public GoldSword() : base("Золотий Меч", "+25 до атаки", 25)
        {
        }
    }
}
=======
        public void Equip(Player player)
        {
            Console.WriteLine($"{Name} екіпійовано! (+{Damage} До атаки)");
        }

        public void Unequip(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"{ player Name} екіпірує {Name}");
            Equip(player);
        }
    }
>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Weapon.cs
