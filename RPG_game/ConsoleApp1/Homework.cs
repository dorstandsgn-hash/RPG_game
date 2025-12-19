namespace RPG_game
{
    public class Homework : Enemy
    {
        public Homework() : base(400, 20, "Домашка", 30)
        {
        }

        public override void Attack(Character target)
        {
            var damage = Strength;
            Console.WriteLine($"{Name} б'є морально і завдає психічну травму");
            target.TakeDamage(damage);
        }
    }
