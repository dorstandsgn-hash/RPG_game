namespace TextRPG
{
    /// <summary>
    /// Троль - сильний ворог
    /// </summary>
    public class Troll : Enemy
    {
        public Troll() : base("Троль", 80, 15, 60)
        {
            AddLoot(new ManaPotion());
            AddLoot(new HealthPotion());
        }

        public override void Attack(Character target)
        {
            int damage = Strength;
            Console.WriteLine($"🔨 {Name} розмахує дубиною і завдає {damage} пошкоджень!");
            target.TakeDamage(damage);

            // 30% шанс приголомшити
            Random rand = new Random();
            if (rand.Next(100) < 30)
            {
                Console.WriteLine($"💫 {target.Name} приголомшений!");
            }
        }
    }
}