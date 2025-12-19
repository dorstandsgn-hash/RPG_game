namespace TextRPG
{
    /// <summary>
    /// Гоблін - слабкий ворог
    /// </summary>
    public class Goblin : Enemy
    {
        public Goblin() : base("Гоблін", 40, 8, 30)
        {
            AddLoot(new HealthPotion());
        }

        public override void Attack(Character target)
        {
            int damage = Strength;
            Console.WriteLine($"🗡️ {Name} б'є кинджалом і завдає {damage} пошкоджень!");
            target.TakeDamage(damage);
        }
    }
}