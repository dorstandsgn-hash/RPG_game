using System;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static RPG_game.Enemy;

namespace RPG_game
{
    public class Weapon : Item, IEquippable
    {
        public int Damage { get; protected set; }
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }

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
