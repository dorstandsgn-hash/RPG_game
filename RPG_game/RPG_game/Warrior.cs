namespace TextRPG
{
    /// <summary>
    /// Воїн - середній ворог
    /// </summary>
    public class Warrior : Enemy
    {
        public Warrior() : base("Воїн", 50, 10, 30)
        {
            AddLoot(new HealthPotion());
        }

        public override void Attack(Character target)
        {
            int damage = Strength;
            Console.WriteLine($"🏹"️ {Name} стріляє і завдає {damage} пошкоджень!");
            target.TakeDamage(damage);
        }
    }