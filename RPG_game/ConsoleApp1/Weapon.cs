namespace TextRPG
{
    /// <summary>
    /// Базовий клас зброї
    /// </summary>
    public abstract class Weapon : Item, IEquippable
    {
        public int Damage { get; protected set; }

        protected Weapon(string name, string description, int damage)
            : base(name, description)
        {
            Damage = damage;
        }

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